#include<Windows.h>    
// first include Windows.h header file which is required    
#include<stdio.h>
#include "GL/glew.h"
#include<gl/GL.h>   // GL.h header file    
#include<gl/GLU.h> // GLU.h header file    
#include<gl/glut.h>  // glut.h header file from freeglut\include\GL folder    
#include<conio.h>
#include<math.h>
#include<string>
#include <vector>
#include <glm/glm.hpp>
#include <string>
#include <sstream>
#include <fstream>
#include <iostream>
#include <cmath>

#include <glm/gtc/matrix_transform.hpp>

int width = 0, height = 0;

GLuint Program;
GLint Attrib_vertex, Unif_color, Unif_matrix, Unif_proj;

float angle_x = 90.0f, angle_y = 90.0f, angle_z = 90.0f;
int axis = 0;
float scale_x = 1, scale_y = 1, scale_z = 1;
int IMG_IDX = 0;


std::string read_shader(const char* path)
{
	std::string res = "";
	std::ifstream file(path);
	std::string line;
	getline(file, res, '\0');
	while (getline(file, line))
	{
		res += "\n " +line;
	}
	return res;
}

//Загрузить и скомпилировать шейдер из файла. Возвращает дескриптор шейдера
GLuint load_shader(int shader_type, std::string shader_path) {
	std::string readed = read_shader(shader_path.c_str());
	const char* sh_source = readed.c_str();
	GLuint shader;
	shader = glCreateShader(shader_type);
	glShaderSource(shader, 1, &sh_source, NULL);
	glCompileShader(shader);
	return shader;
}

//загрузить шейдеры для изображения
void initShader()
{
	GLuint vShader, fShader;
	vShader = load_shader(GL_VERTEX_SHADER, "vertex_shader");
	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment_shader");

	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);
	glLinkProgram(Program);

	int link_res;
	glGetProgramiv(Program, GL_LINK_STATUS, &link_res);

	const char* attr_name = "pos";
	Attrib_vertex = glGetAttribLocation(Program, attr_name);

	const char* color_name = "col";
	Unif_color = glGetUniformLocation(Program, color_name);

	const char* matrix_name = "matr";
	Unif_matrix = glGetUniformLocation(Program, matrix_name);

	const char* proj_name = "projection";
	Unif_proj = glGetUniformLocation(Program, proj_name);
}	 

//удалить скомпилированные шейдеры
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
	float angle_cos = sin(angle_x*3.14 / 180);
	glm::mat4 rotate_ox = { 1.0f,   0.0f,     0.0f,   0.0f,
					 0.0f,  angle_cos,   -angle_sin,  0.0f,
					 0.0f,  angle_sin,  angle_cos,  0.0f,
					 0.0f,   0.0f,     0.0f,   1.0f };


	angle_sin = sin(angle_y*3.14 / 180);
	angle_cos = sin(angle_y*3.14 / 180);

	glm::mat4 rotate_oy = { angle_cos, 0.0f, -angle_sin, 0.0f,
		             0.0f, 1.0f, 0.0f, 0.0f,
		             angle_sin, 0.0f, angle_cos, 0.0f,
		             0.0f, 0.0f, 0.0f, 1.0f };

	angle_sin = sin(angle_z*3.14 / 180);
	angle_cos = sin(angle_z*3.14 / 180);
	glm::mat4 rotate_oz = { angle_cos, angle_sin, 0.0f, 0.0f,
		            -angle_sin, angle_cos, 0.0f, 0.0f,
		             0.0f, 0.0f, 1.0f, 0.0f,
		             0.0f, 0.0f, 0.0f, 1.0f };
	
	glm::mat4 res = matrixCompMult(rotate_oy, rotate_ox);
	return res; //rotate_ox;
}
void display(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	glUseProgram(Program);
	float col[4] = { 0.0f, 1.0f, 0.0f, 1.0f };
	glUniform4fv(Unif_color, 1, col);
	
	glm::mat4 Projection = glm::perspective(glm::radians(45.0f), (float)width / (float)height, 0.1f, 100.0f);
	glm::mat4 View = glm::lookAt(
		glm::vec3(0, 5, 10),
		glm::vec3(0, 0, 0),
		glm::vec3(0, 1, 0)
	);

	glm::mat4 MVP = Projection * View;
	glUniformMatrix4fv(Unif_proj, 1, GL_FALSE, &MVP[0][0]);

	glm::mat4 S = { scale_x, 0.0f,0.0f, 0.0f,
					0.0f , scale_y, 0.0f, 0.0f ,
					0.0f ,0.0f , scale_z, 0.0f ,
					0.0f ,0.0f ,0.0f, 1.0f };
	float a = angle_x * 3.14f / 180.0f;
	glm::mat4 R = rotate_matrix();

	glm::mat4 Matrix = glm::matrixCompMult(S, R);
	
	glUniformMatrix4fv(Unif_matrix, 1, GL_FALSE, &Matrix[0][0]);
	glutSolidCube(1);
	glFlush();
	glUseProgram(0);
	glutSwapBuffers();
}

void special_keys_mapping(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_F1: IMG_IDX = 0;
		break;
	case GLUT_KEY_F2: IMG_IDX = 1;
		break;
	}
}

void keyboard_mapping(unsigned char key, int x, int y)
{
	if (IMG_IDX)
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

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH|GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(800, 800);
	glutInitWindowPosition(10, 10);
	glutCreateWindow("Lab 12");
	
	GLenum glew_status = glewInit();
	initShader();

	init();
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard_mapping);
	glutSpecialFunc(special_keys_mapping);
	glutMainLoop();

	freeShader();
}