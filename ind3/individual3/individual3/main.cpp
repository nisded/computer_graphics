#include <string>
#include <vector>
#include <string>
#include <sstream>
#include <fstream>
#include <iostream>
#include <map>
#include <GL/glew.h>
#include <SOIL.h>
#include <gl/freeglut.h> 
#include <glm/glm.hpp> 
#include <glm/gtc/matrix_transform.hpp>

using namespace std;

int width = 0, height = 0;

const double PI = 3.1415926535;
GLuint shader_program;

const int obj_num = 5;
vector<GLuint> object_textures(obj_num), VAOs(obj_num);
vector<string> object_paths = { "objects/simple_floor.obj", "objects/table.obj", "objects/turkey.obj", "objects/square_plate.obj", "objects/glass.obj" };
vector<string> object_texture_paths = { "objects/carpet.jpg", "objects/table_wood.jpg", "objects/turkey.jpg", "objects/plate.jpg", "objects/glass.jpg" };
vector<double> object_scales = { 8, 1, 0.05, 0.1, 0.05 };

vector <GLuint> vertex_buffers(obj_num), uv_buffers(obj_num), normal_buffers(obj_num), element_buffers(obj_num);
vector<vector<unsigned short>> object_indices(obj_num, vector<unsigned short>());

glm::mat4 model_pos, view_projection;
glm::mat3 normal_transform;
float view_pos[]{ 0, 10, -20 };
float light_angle = 0, light_pos = 20, light_radius = 30;
float light_position[]{ 0, 0, 0 };

float rotateX = 0, rotateY = 0, rotateZ = 0;

string read_shader(const char* path)
{
	string res = "";
	ifstream file(path);
	string line;
	getline(file, res, '\0');
	while (getline(file, line))
		res += "\n " + line;
	return res;
}

void init_shaders() 
{
	string read_v = read_shader("vertex.shader");
	const char* v_shader_source = read_v.c_str();
	string read_f = read_shader("fragment.shader");
	const char* f_shader_source = read_f.c_str();

	GLuint v_shader, f_shader;
	v_shader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(v_shader, 1, &v_shader_source, NULL);
	glCompileShader(v_shader);
	f_shader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(f_shader, 1, &f_shader_source, NULL);
	glCompileShader(f_shader);

	shader_program = glCreateProgram();
	glAttachShader(shader_program, v_shader);
	glAttachShader(shader_program, f_shader);
	glLinkProgram(shader_program);
	glDeleteShader(v_shader);
	glDeleteShader(f_shader);
}

void reshape(int w, int h)
{
	width = w;
	height = h;
	glViewport(0, 0, w, h);
}

void load_textures(const vector<string>& texture_names, vector<GLuint>& object_textures)
{
	for (int i = 0; i < texture_names.size(); ++i) {
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		object_textures[i] = SOIL_load_OGL_texture(texture_names[i].c_str(), SOIL_LOAD_AUTO,
			SOIL_CREATE_NEW_ID,
			SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);
	}
}

void loadOBJ(const string& path, vector<glm::vec3>& out_vertices, vector<glm::vec2>& out_uvs, vector<glm::vec3>& out_normals, const double& scale)
{
	vector<unsigned int> vertex_indices, uv_indices, normal_indices;
	vector<glm::vec3> temp_vertices;
	vector<glm::vec2> temp_uvs;
	vector<glm::vec3> temp_normals;

	ifstream infile(path);
	string line;
	while (getline(infile, line))
	{
		stringstream ss(line);
		string lineHeader;
		getline(ss, lineHeader, ' ');
		if (lineHeader == "v")
		{
			glm::vec3 vertex;
			ss >> vertex.x >> vertex.y >> vertex.z;
			vertex.x *= scale;
			vertex.y *= scale;
			vertex.z *= scale;
			temp_vertices.push_back(vertex);
		}
		else if (lineHeader == "vt")
		{
			glm::vec2 uv;
			ss >> uv.x >> uv.y;
			temp_uvs.push_back(uv);
		}
		else if (lineHeader == "vn")
		{
			glm::vec3 normal;
			ss >> normal.x >> normal.y >> normal.z;
			temp_normals.push_back(normal);
		}
		else if (lineHeader == "f")
		{
			unsigned int vertex_index, uv_index, normal_index;
			char slash;
			while (ss >> vertex_index >> slash >> uv_index >> slash >> normal_index)
			{
				vertex_indices.push_back(vertex_index);
				uv_indices.push_back(uv_index);
				normal_indices.push_back(normal_index);
			}
		}
	}

	for (unsigned int i = 0; i < vertex_indices.size(); i++)
	{
		unsigned int vertexIndex = vertex_indices[i];
		glm::vec3 vertex = temp_vertices[vertexIndex - 1];
		out_vertices.push_back(vertex);

		unsigned int uvIndex = uv_indices[i];
		glm::vec2 uv = temp_uvs[uvIndex - 1];
		out_uvs.push_back(uv);

		unsigned int normalIndex = normal_indices[i];
		glm::vec3 normal = temp_normals[normalIndex - 1];
		out_normals.push_back(normal);
	}
}

struct PackedVertex
{
	glm::vec3 position;
	glm::vec2 uv;
	glm::vec3 normal;
	bool operator<(const PackedVertex that) const
	{
		return memcmp((void*)this, (void*)& that, sizeof(PackedVertex)) > 0;
	};
};

void indexVBO(vector<glm::vec3>& in_vertices, vector<glm::vec2>& in_uvs, vector<glm::vec3>& in_normals,
	vector<unsigned short>& out_indices, vector<glm::vec3>& out_vertices, vector<glm::vec2>& out_uvs, vector<glm::vec3>& out_normals)
{
	std::map<PackedVertex, unsigned short> VertexToOutIndex;

	for (unsigned int i = 0; i < in_vertices.size(); ++i)
	{
		PackedVertex packed = { in_vertices[i], in_uvs[i], in_normals[i] };

		unsigned short index;
		auto it = VertexToOutIndex.find(packed);
		if (it != VertexToOutIndex.end()) 
			out_indices.push_back(it->second);
		else
		{ 
			out_vertices.push_back(in_vertices[i]);
			out_uvs.push_back(in_uvs[i]);
			out_normals.push_back(in_normals[i]);
			unsigned short newindex = (unsigned short)out_vertices.size() - 1;
			out_indices.push_back(newindex);
			VertexToOutIndex[packed] = newindex;
		}
	}
}

void init_buffers(const vector<string>& object_names, const vector<double>& object_scales, vector <GLuint>& vertex_buffers, vector <GLuint>& uv_buffers,
	vector <GLuint>& normal_buffers, vector <GLuint>& element_buffers, vector<GLuint>& VAOs)
{
	for (int i = 0; i < object_names.size(); ++i) {
		vector<glm::vec3> vertices, normals, indexed_vertices, indexed_normals;
		vector<glm::vec2> uvs, indexed_uvs;

		loadOBJ(object_names[i].c_str(), vertices, uvs, normals, object_scales[i]);
		indexVBO(vertices, uvs, normals, object_indices[i], indexed_vertices, indexed_uvs, indexed_normals);

		glGenBuffers(1, &vertex_buffers[i]);
		glGenBuffers(1, &uv_buffers[i]);
		glGenBuffers(1, &normal_buffers[i]);
		glGenBuffers(1, &element_buffers[i]);

		glGenVertexArrays(1, &VAOs[i]);
		glBindVertexArray(VAOs[i]);

		glBindBuffer(GL_ARRAY_BUFFER, vertex_buffers[i]);
		glBufferData(GL_ARRAY_BUFFER, indexed_vertices.size() * sizeof(glm::vec3), &indexed_vertices[0], GL_STATIC_DRAW);

		glBindBuffer(GL_ARRAY_BUFFER, uv_buffers[i]);
		glBufferData(GL_ARRAY_BUFFER, indexed_uvs.size() * sizeof(glm::vec2), &indexed_uvs[0], GL_STATIC_DRAW);

		glBindBuffer(GL_ARRAY_BUFFER, normal_buffers[i]);
		glBufferData(GL_ARRAY_BUFFER, indexed_normals.size() * sizeof(glm::vec3), &indexed_normals[0], GL_STATIC_DRAW);

		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, element_buffers[i]);
		glBufferData(GL_ELEMENT_ARRAY_BUFFER, object_indices[i].size() * sizeof(unsigned short), &(object_indices[i])[0], GL_STATIC_DRAW);

		glBindBuffer(GL_ARRAY_BUFFER, vertex_buffers[i]);
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, 0);
		glEnableVertexAttribArray(0);

		glBindBuffer(GL_ARRAY_BUFFER, normal_buffers[i]);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 0, 0);
		glEnableVertexAttribArray(1);

		glBindBuffer(GL_ARRAY_BUFFER, uv_buffers[i]);
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, 0, 0);
		glEnableVertexAttribArray(2);

		glBindVertexArray(0);
	}
}

void set_transform() {
	GLint s_model = glGetUniformLocation(shader_program, "transform.model");
	GLint s_proj = glGetUniformLocation(shader_program, "transform.viewProjection");
	GLint s_normal = glGetUniformLocation(shader_program, "transform.normal");
	GLint s_view = glGetUniformLocation(shader_program, "transform.viewPosition");

	glUniformMatrix4fv(s_model, 1, GL_FALSE, &model_pos[0][0]);
	glUniformMatrix4fv(s_proj, 1, GL_FALSE, &view_projection[0][0]);
	glUniformMatrix3fv(s_normal, 1, GL_FALSE, &normal_transform[0][0]);
	glUniform3fv(s_view, 1, view_pos);
}

void set_point_light() {
	GLint s_position = glGetUniformLocation(shader_program, "light.position");
	GLint s_ambient = glGetUniformLocation(shader_program, "light.ambient");
	GLint s_diffuse = glGetUniformLocation(shader_program, "light.diffuse");
	GLint s_specular = glGetUniformLocation(shader_program, "light.specular");
	GLint s_attenuation = glGetUniformLocation(shader_program, "light.attenuation");

	float ambient[]{ 0.2f, 0.2f, 0.2f, 1.0f };
	float diffuse[]{ 1.0f, 1.0f, 1.0f, 1.0f };
	float specular[]{ 1.0f, 1.0f, 1.0f, 1.0f };
	float attenuation[]{ 1.0f, 0.0f, 0.0f };

	glUniform4fv(s_position, 1, light_position);
	glUniform4fv(s_ambient, 1, ambient);
	glUniform4fv(s_diffuse, 1, diffuse);
	glUniform4fv(s_specular, 1, specular);
	glUniform3fv(s_attenuation, 1, attenuation);
}

void set_material(float* m_ambient, float* m_diffuse, float* m_specular, float* m_emission, float m_shiness) {
	GLint s_ambient = glGetUniformLocation(shader_program, "material.ambient");
	GLint s_diffuse = glGetUniformLocation(shader_program, "material.diffuse");
	GLint s_specular = glGetUniformLocation(shader_program, "material.specular");
	GLint s_emission = glGetUniformLocation(shader_program, "material.emission");
	GLint s_shiness = glGetUniformLocation(shader_program, "material.shiness");

	glUniform4fv(s_ambient, 1, m_ambient);
	glUniform4fv(s_diffuse, 1, m_diffuse);
	glUniform4fv(s_specular, 1, m_specular);
	glUniform4fv(s_emission, 1, m_emission);
	glUniform1f(s_shiness, m_shiness);
}

void draw_object(int cur_ind, float trans_x, float trans_y, float trans_z, float* m_ambient, float* m_diffuse, float* m_specular, float* m_emission, float m_shiness) {
	glGetUniformLocation(shader_program, "cur_texture");
	glEnable(GL_TEXTURE_2D);
	glBindTexture(GL_TEXTURE_2D, object_textures[cur_ind]);

	glUseProgram(shader_program);
	model_pos = glm::translate(model_pos, glm::vec3(trans_x, trans_y, trans_z));
	set_transform();
	set_point_light();
	set_material(m_ambient, m_diffuse, m_specular, m_emission, m_shiness);

	glBindVertexArray(VAOs[cur_ind]);
	glDrawElements(GL_QUADS, object_indices[cur_ind].size(), GL_UNSIGNED_SHORT, 0);
	glBindVertexArray(0);
	glUseProgram(0);
}

void draw_scene()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();

	model_pos = glm::mat4(1.0f);
	model_pos = glm::rotate(model_pos, glm::radians(rotateX), glm::vec3(1, 0, 0));
	model_pos = glm::rotate(model_pos, glm::radians(rotateY), glm::vec3(0, 1, 0));
	model_pos = glm::rotate(model_pos, glm::radians(rotateZ), glm::vec3(0, 0, 1));

	view_projection = glm::perspective(45.0f, (float)width / (float)height, 0.1f, 100.0f);
	view_projection *= lookAt(glm::vec3(view_pos[0], view_pos[1], view_pos[2]), glm::vec3(0, 0, 0), glm::vec3(0, 1, 0));
	normal_transform = transpose(inverse(model_pos));

	float m_ambient[] = { 1.0f, 1.0f, 1.0f, 1.0f };
	float m_diffuse[] = { 1.0f, 1.0f, 1.0f, 1.0f };
	float m_specular[] = { 0.2f, 0.2f, 0.2f, 1.0f };
	float m_emission[] = { 0.0f, 0.0f, 0.0f, 1.0f };
	float m_shininess = 0;

	int cur_ind = 0;
	draw_object(cur_ind, 0, 0, 0, m_ambient, m_diffuse, m_specular, m_emission, m_shininess);

	++cur_ind;
	draw_object(cur_ind, 0, 0, 0, m_ambient, m_diffuse, m_specular, m_emission, m_shininess);

	++cur_ind;
	model_pos = glm::rotate(model_pos, glm::radians(-90.0f), glm::vec3(1, 0, 0));
	draw_object(cur_ind, 0, 0, 7.2, m_ambient, m_diffuse, m_specular, m_emission, m_shininess);
	model_pos = glm::rotate(model_pos, glm::radians(90.0f), glm::vec3(1, 0, 0));

	++cur_ind;
	draw_object(cur_ind, 0, 0, 0, m_ambient, m_diffuse, m_specular, m_emission, m_shininess);

	++cur_ind;
	float material_ambient[] = { 1.0, 1.0, 1.0, 1.0 };
	float material_diffuse[] = { 0.2, 0.2, 0.2, 1.0 };
	float material_shininess = 200.0f;
	float material_specular[] = { 0.8, 0.8, 0.8, 1.0 };
	float material_emission[] = { 0.1, 0.1, 0.2, 1.0 };
	draw_object(cur_ind, 2, 0, 0, material_ambient, material_diffuse, material_specular, material_emission, material_shininess);

	if (glIsEnabled(GL_TEXTURE_2D))
		glDisable(GL_TEXTURE_2D);
	glutSwapBuffers();
}

void update_light()
{
	light_position[0] = light_radius * cos(light_angle / 180 * PI);
	light_position[1] = light_pos;
	light_position[2] = light_radius * sin(light_angle / 180 * PI);
}

void light_change(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_UP:
		light_pos += 0.5;
		break;
	case GLUT_KEY_DOWN:
		light_pos -= 0.5;
		break;
	case GLUT_KEY_RIGHT:
		light_angle -= 3;
		break;
	case GLUT_KEY_LEFT:
		light_angle += 3;
		break;
	case GLUT_KEY_PAGE_UP:
		light_radius -= 0.5;
		break;
	case GLUT_KEY_PAGE_DOWN:
		light_radius += 0.5;
		break;
	default:
		break;
	}
	update_light();
	glutPostRedisplay();
}

void keyboard_rotate(unsigned char key, int x, int y)
{
	switch (key)
	{
	case 'w':
		rotateX -= 2;
		break;
	case 's':
		rotateX += 2;
		break;
	case 'q':
		rotateY -= 2;
		break;
	case 'e':
		rotateY += 2;
		break;
	case 'a':
		rotateZ -= 2;
		break;
	case 'd':
		rotateZ += 2;
		break;
	default:
		break;
	}
	glutPostRedisplay();
}

int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(100, 100);
	glutCreateWindow("Individual task 3");
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT1);

	glewInit();
	init_shaders();
	load_textures(object_texture_paths, object_textures);
	init_buffers(object_paths, object_scales, vertex_buffers, uv_buffers, normal_buffers, element_buffers, VAOs);

	glClearColor(0, 0, 0, 1.0);
	glEnable(GL_DEPTH_TEST);
	update_light();
	glutDisplayFunc(draw_scene);
	glutReshapeFunc(reshape);
	glutSpecialFunc(light_change);
	glutKeyboardFunc(keyboard_rotate);
	glutMainLoop();
}