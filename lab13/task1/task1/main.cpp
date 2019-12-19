#include"GL/glew.h"
#include"GL/freeglut.h"
#include<vector>
#include<glm/glm.hpp>
#include<string>
#include<sstream>
#include<fstream>
#include<map>
#include<ctime>
#include<random>

//вершины объекта
std::vector<glm::vec3> indexed_vertices;
//цвета дл¤ каждой вершины объекта
std::vector<glm::vec3> color_vertices;
//индексы вершин дл¤ соединени¤ вершин в грани
std::vector<unsigned short> indices;

GLuint vertexbuffer;
GLuint indexbuffer;
GLuint colorsbuffer;

const double pi = 3.14159265358979323846;
int light_num = 0;
std::vector<float> light_angle{ 0, 90, 180 };
std::vector<float> light_pos{ 5, 5, 5 };
std::vector<float> light_rad{ 10, 10, 10 };
float model_angle = 0;
int is_ahead = 0;
int is_back = 0;
int width = 0, height = 0;
float x = 0; float z = 0; float y = 0;
float SPEED = 0.1;

struct VertexData
{
	glm::vec3 vertex;
	bool operator<(const VertexData that) const
	{
		return memcmp((void*)this, (void*)& that, sizeof(VertexData)) > 0;
	};
};

//из входного вектора вершин, которые повтор¤ютс¤, делает два выходных вектора: в первом неповтор¤ющиес¤ вершины, 
//во втором индексы на вершины в первом векторе
void indexVBO(std::vector<glm::vec3>& in_vertices, std::vector<unsigned short>& out_indices, std::vector<glm::vec3>& out_vertices)
{
	std::map<VertexData, unsigned short> VertexToOutIndex;

	for (unsigned int i = 0; i < in_vertices.size(); ++i)
	{
		VertexData packed = { in_vertices[i] };
		unsigned short index;
		auto it = VertexToOutIndex.find(packed);
		if (it != VertexToOutIndex.end()) // check if vertex already exists
			out_indices.push_back(it->second);
		else
		{
			out_vertices.push_back(in_vertices[i]);
			unsigned short newindex = (unsigned short)out_vertices.size() - 1;
			out_indices.push_back(newindex);
			VertexToOutIndex[packed] = newindex;
		}
	}
}

//образует вектор вершин, в пор¤дке очередности индексов вершин треугольников дл¤ граней
void read_obj(const std::string& path, std::vector<glm::vec3>& out_vertices)
{
	std::vector<unsigned int> vertex_indices;
	std::vector<glm::vec3> temp_vertices;

	std::ifstream infile(path);
	std::string line;
	while (getline(infile, line))
	{
		std::stringstream ss(line);
		std::string firstSymbol;
		getline(ss, firstSymbol, ' ');
		if (firstSymbol == "v")
		{
			glm::vec3 vertex;
			ss >> vertex.x >> vertex.y >> vertex.z;
			vertex.x *= 0.1;
			vertex.y *= 0.1;
			vertex.z *= 0.1;
			temp_vertices.push_back(vertex);
		}
		else if (firstSymbol == "f")
		{
			unsigned int vertex_index[3];
			char slash;
			ss >> vertex_index[0] >> vertex_index[1] >> vertex_index[2];

			vertex_indices.push_back(vertex_index[0]);
			vertex_indices.push_back(vertex_index[1]);
			vertex_indices.push_back(vertex_index[2]);
		}
	}

	// For each vertex of each triangle
	for (unsigned int i = 0; i < vertex_indices.size(); ++i)
	{
		unsigned int vertexIndex = vertex_indices[i];
		glm::vec3 vertex = temp_vertices[vertexIndex - 1];
		out_vertices.push_back(vertex);
	}
}

//генерирует цвета дл¤ каждой вершины
void gen_colors(int size)
{
	color_vertices.clear();
	for (int i = 0; i < size; ++i)
	{
		glm::vec3 color;
		color.x = (float)rand() / RAND_MAX;
		color.y = (float)rand() / RAND_MAX;
		color.z = (float)rand() / RAND_MAX;
		color_vertices.push_back(color);
	}
}

void init(void)
{
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glEnable(GL_NORMALIZE);
	glEnable(GL_COLOR_MATERIAL);
	glEnable(GL_CULL_FACE);

	// Street lights
	const GLfloat light_ambient[] = { 0.0, 0.0, 0.0, 1 };
	const GLfloat light_diffuse[] = { 1.0, 1.0, 1.0, 1.0 };
	const GLfloat light_specular[] = { 1.0, 1.0, 1.0, 1.0 };
	glLightfv(GL_LIGHT1, GL_AMBIENT, light_ambient);
	glLightfv(GL_LIGHT1, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT1, GL_SPECULAR, light_specular);

	glLightfv(GL_LIGHT2, GL_AMBIENT, light_ambient);
	glLightfv(GL_LIGHT2, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT2, GL_SPECULAR, light_specular);

	glLightfv(GL_LIGHT3, GL_AMBIENT, light_ambient);
	glLightfv(GL_LIGHT3, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT3, GL_SPECULAR, light_specular);

	glEnable(GL_DEPTH_TEST);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT1);

	// Read our .obj file
	std::vector<glm::vec3> vertices;
	read_obj("cube.obj", vertices);
	indexVBO(vertices, indices, indexed_vertices);
	gen_colors(indexed_vertices.size());
}

double gr_cos(float angle) noexcept
{
	return cos(angle / 180 * pi);
}

double gr_sin(float angle) noexcept
{
	return sin(angle / 180 * pi);
}

void set_lights()
{
	double x = light_rad[0] * gr_cos(light_angle[0]);
	double z = light_rad[0] * gr_sin(light_angle[0]);
	GLfloat position[] = { 0, 0, 0, 1 };
	GLfloat light[] = { 1, 1, 1, 1 };
	GLfloat no_light[] = { 0, 0, 0, 1 };
	if (glIsEnabled(GL_LIGHT1))
	{
		glPushMatrix();
		glTranslatef(x, light_pos[0], z);
		glLightfv(GL_LIGHT1, GL_POSITION, position);
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
		glutSolidSphere(0.5, 10, 10);
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
		glPopMatrix();
	}

	if (glIsEnabled(GL_LIGHT2))
	{
		glPushMatrix();
		x = light_rad[1] * gr_cos(light_angle[1]);
		z = light_rad[1] * gr_sin(light_angle[1]);
		glTranslatef(x, light_pos[1], z);
		glLightfv(GL_LIGHT2, GL_POSITION, position);
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
		glutSolidSphere(0.5, 10, 10);
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
		glPopMatrix();
	}

	if (glIsEnabled(GL_LIGHT3))
	{
		glPushMatrix();
		x = light_rad[2] * gr_cos(light_angle[2]);
		z = light_rad[2] * gr_sin(light_angle[2]);
		glTranslatef(x, light_pos[2], z);
		glLightfv(GL_LIGHT3, GL_POSITION, position);
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
		glutSolidSphere(0.5, 10, 10);
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
		glPopMatrix();
	}
}

void reshape(int w, int h)
{
	width = w; height = h;
	glViewport(0, 0, w, h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(60.0, w / h, 1.0, 100.0);
	gluLookAt(0, 10, 30, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}

void prepare_buffers()
{
	glGenBuffers(1, &vertexbuffer);
	glBindBuffer(GL_ARRAY_BUFFER, vertexbuffer);
	glBufferData(GL_ARRAY_BUFFER, indexed_vertices.size() * sizeof(glm::vec3), &indexed_vertices[0], GL_STATIC_DRAW);

	glGenBuffers(1, &colorsbuffer);
	glBindBuffer(GL_ARRAY_BUFFER, colorsbuffer);
	glBufferData(GL_ARRAY_BUFFER, color_vertices.size() * sizeof(glm::vec3), &color_vertices[0], GL_STATIC_DRAW);

	glGenBuffers(1, &indexbuffer);
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, indexbuffer);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, indices.size() * sizeof(unsigned short), &indices[0], GL_STATIC_DRAW);
}

void set_vertex_params()
{
	// 1rst attribute buffer : vertices
	glEnableVertexAttribArray(0);
	glBindBuffer(GL_ARRAY_BUFFER, vertexbuffer);
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, 0);

	glEnableClientState(GL_COLOR_ARRAY);
	glEnableVertexAttribArray(1);
	glBindBuffer(GL_ARRAY_BUFFER, colorsbuffer);
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 0, 0);
	glColorPointer(3, GL_FLOAT, 0, 0);
}

void cleanup_buffers()
{
	glDisableClientState(GL_COLOR_ARRAY);
	glDeleteBuffers(1, &vertexbuffer);
	glDeleteBuffers(1, &indexbuffer);
	glDeleteBuffers(1, &colorsbuffer);
	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
}

void _draw_model()
{
	prepare_buffers();
	set_vertex_params();
	// Draw the triangles
	glDrawElements(GL_TRIANGLES, indices.size(), GL_UNSIGNED_SHORT, 0);
	cleanup_buffers();
}

void draw_model()
{
	glPushMatrix();
	glTranslatef(x, y, z);
	glRotatef(model_angle, 0, 1, 0);
	//glColor3f(0.8, 0.8, 0.8);
	_draw_model();
	glPopMatrix();
}

void display(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	if (is_ahead)
	{
		x += SPEED * gr_sin(model_angle);
		z += SPEED * gr_cos(model_angle);
		is_ahead = 0;
	}
	if (is_back)
	{
		x -= SPEED * gr_sin(model_angle);
		z -= SPEED * gr_cos(model_angle);
		is_back = 0;
	}

	set_lights();
	draw_model();
	glutSwapBuffers();
}

void specialKeys(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_UP: light_pos[light_num] += 0.5; break;
	case GLUT_KEY_DOWN: light_pos[light_num] -= 0.5; break;
	case GLUT_KEY_RIGHT: light_angle[light_num] -= 3; break;
	case GLUT_KEY_LEFT: light_angle[light_num] += 3; break;
	case GLUT_KEY_PAGE_UP: light_rad[light_num] -= 0.5; break;
	case GLUT_KEY_PAGE_DOWN: light_rad[light_num] += 0.5; break;
	case GLUT_KEY_F1:
		light_num = 0;
		break;
	case GLUT_KEY_F2:
		light_num = 1;
		break;
	case GLUT_KEY_F3:
		light_num = 2;
		break;
	}
	glutPostRedisplay();
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key)
	{
	case '1':
		if (glIsEnabled(GL_LIGHT1))
			glDisable(GL_LIGHT1);
		else
			glEnable(GL_LIGHT1);
		break;
	case '2':
		if (glIsEnabled(GL_LIGHT2))
			glDisable(GL_LIGHT2);
		else
			glEnable(GL_LIGHT2);
		break;
	case '3':
		if (glIsEnabled(GL_LIGHT3))
			glDisable(GL_LIGHT3);
		else
			glEnable(GL_LIGHT3);
		break;
	case 'a':
	case 'A':
		model_angle += 5;
		break;
	case 'd':
	case 'D':
		model_angle -= 5;
		break;
	case 'w':
	case 'W':
		is_ahead = 1;
		break;
	case 's':
	case 'S':
		is_back = 1;
		break;
	}
	glutPostRedisplay();
}

int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(10, 10);
	glutCreateWindow("Lab13/task1");
	glewInit();
	srand(time(0));
	init();
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutSpecialFunc(specialKeys);
	glutKeyboardFunc(keyboard);
	glutMainLoop();
	return 0;
}