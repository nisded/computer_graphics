#include"GL/glew.h"
#include"GL/freeglut.h"
#include<string>
#include<fstream>

#include<glm/gtc/matrix_transform.hpp>

int width = 0, height = 0;

GLint Attrib_vertex, Unif_MVP, Unif_color;
GLuint Program;

float angle_x = 0, angle_y = 0, angle_z = 0;
float scale_x = 1, scale_y = 1, scale_z = 1;
//0 - scale, 1 - rotate
int transform_mode = 0;

std::string read_shader(std::string path)
{
	std::string res = "";
	std::ifstream file(path);
	std::string line;
	getline(file, res, '\n');
	while (getline(file, line))
	{
		res += "\n" + line;
	}
	return res;
}

//Загрузить и скомпилировать шейдер из файла. Возвращает дескриптор шейдера
GLuint load_shader(int shader_type, std::string shader_path) {
	std::string readed = read_shader(shader_path);
	const char* source = readed.c_str();
	GLuint shader;
	shader = glCreateShader(shader_type);
	glShaderSource(shader, 1, &source, NULL);
	glCompileShader(shader);
	return shader;
}

void initShader()
{
	GLuint vShader, fShader;
	vShader = load_shader(GL_VERTEX_SHADER, "vertex_shader");
	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment_shader");

	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);
	glLinkProgram(Program);

	glDeleteShader(vShader);
	glDeleteShader(fShader);

	const char* coord_name = "coord";
	Attrib_vertex = glGetAttribLocation(Program, coord_name);

	const char* color_name = "color";
	Unif_color = glGetUniformLocation(Program, color_name);

	const char* MVP_name = "MVP";
	Unif_MVP = glGetUniformLocation(Program, MVP_name);
}

void freeShader() {
	glUseProgram(0);
	glDeleteProgram(Program);
}

void init(void) {
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glEnable(GL_DEPTH_TEST);
}

void reshape(int w, int h) {
	width = w; height = h;
	glViewport(0, 0, w, h);
}

glm::mat4 rotate_matrix() {
	float angle_sin = sin(angle_x * 3.14 / 180);
	float angle_cos = cos(angle_x * 3.14 / 180);
	glm::mat4 rotate_ox = { 1.0f,   0.0f,     0.0f,   0.0f,
					 0.0f,  angle_cos,   -angle_sin,  0.0f,
					 0.0f,  angle_sin,  angle_cos,  0.0f,
					 0.0f,   0.0f,     0.0f,   1.0f };


	angle_sin = sin(angle_y * 3.14 / 180);
	angle_cos = cos(angle_y * 3.14 / 180);

	glm::mat4 rotate_oy = { angle_cos, 0.0f, angle_sin, 0.0f,
					 0.0f, 1.0f, 0.0f, 0.0f,
					 -angle_sin, 0.0f, angle_cos, 0.0f,
					 0.0f, 0.0f, 0.0f, 1.0f };

	angle_sin = sin(angle_z * 3.14 / 180);
	angle_cos = cos(angle_z * 3.14 / 180);
	glm::mat4 rotate_oz = { angle_cos, -angle_sin, 0.0f, 0.0f,
					angle_sin, angle_cos, 0.0f, 0.0f,
					 0.0f, 0.0f, 1.0f, 0.0f,
					 0.0f, 0.0f, 0.0f, 1.0f };

	glm::mat4 res = rotate_ox * rotate_oy * rotate_oz;
	return res;
}

void display(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	glUseProgram(Program);
	float col[4] = { 0.4f, 0.0f, 0.3f, 1.0f };
	glUniform4fv(Unif_color, 1, col);

	glm::mat4 Projection = glm::perspective(glm::radians(45.0f), (float)width / (float)height, 0.1f, 100.0f);
	glm::mat4 View = glm::lookAt(
		glm::vec3(0, 2, 4),
		glm::vec3(0, 0, 0),
		glm::vec3(0, 1, 0)
	);

	glm::mat4 MVP = Projection * View;

	glm::mat4 Scale_Matrix = { scale_x, 0.0f,0.0f, 0.0f,
				0.0f , scale_y, 0.0f, 0.0f ,
				0.0f ,0.0f , scale_z, 0.0f ,
				0.0f ,0.0f ,0.0f, 1.0f };

	glm::mat4 Rotation_Matrix = rotate_matrix();

	MVP *= Scale_Matrix * Rotation_Matrix;

	glUniformMatrix4fv(Unif_MVP, 1, GL_FALSE, &MVP[0][0]);

	glutWireCube(1);

	glFlush();
	glUseProgram(0);
	glutSwapBuffers();
}

void special_keys(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_F1: transform_mode = 0;
		break;
	case GLUT_KEY_F2: transform_mode = 1;
		break;
	}
}

void keyboard(unsigned char key, int x, int y)
{
	if (transform_mode)
	{
		switch (key)
		{
		case '1': angle_x += 5;
			break;
		case '2': angle_x -= 5;
			break;
		case '3': angle_y += 5;
			break;
		case '4': angle_y -= 5;
			break;
		case '5': angle_z += 5;
			break;
		case '6': angle_z -= 5;
			break;
		}
	}
	else
		switch (key)
		{
		case '1': scale_x += 0.1;
			break;
		case '2': scale_x -= 0.1;
			break;
		case '3': scale_y += 0.1;
			break;
		case '4': scale_y -= 0.1;
			break;
		case '5': scale_z += 0.1;
			break;
		case '6': scale_z -= 0.1;
			break;
		}
	glutPostRedisplay();
}

int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(10, 10);
	glutCreateWindow("Lab 12/task1");

	glewInit();
	initShader();
	init();

	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard);
	glutSpecialFunc(special_keys);
	glutMainLoop();

	freeShader();
}