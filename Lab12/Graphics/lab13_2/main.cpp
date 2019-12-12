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

#include <glm/gtc/matrix_transform.hpp>

int width = 0, height = 0;
int IMG_IDX = 1;
GLuint Program, vProgram, hProgram;
GLint Attrib_vertex, Unif_color;
GLint Unif_v_color1, Unif_v_color2;
GLint Unif_h_color1, Unif_h_color2;
GLint Unif_v_lines, Unif_h_lines;
float v_color1[]{ 1, 1, 0, 1 };
float v_color2[]{ 0, 1, 0, 0 };
float h_color1[]{ 1, 1, 0, 1 };
float h_color2[]{ 0, 1, 0, 0 };
int ver_line = 30;
int hor_line = 30;

std::string read_shader(std::string path)
{
	std::string res = "";
	std::ifstream file(path);
	std::string line;
	getline(file, res, '\0');
	while (getline(file, line))
		res += "\n " + line;
	return res;
}

//«агрузить и скомпилировать шейдер из файла. ¬озвращает дескриптор шейдера
GLuint load_shader(int shader_type, std::string shader_path) {
	std::string readed = read_shader(shader_path.c_str());
	const char* sh_source = readed.c_str();
	GLuint shader;
	shader = glCreateShader(shader_type);
	glShaderSource(shader, 1, &sh_source, NULL);
	glCompileShader(shader);
	return shader;
}

//загрузить шейдеры дл€ закрашенного изображени€
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

	Attrib_vertex = glGetAttribLocation(Program, "coord");
	Unif_color = glGetUniformLocation(Program, "color");
}


//загрузить шейдеры дл€ вертикально заштрихованного изображени€
void initVertShader() {
	GLuint vShader, fShader;
	vShader = load_shader(GL_VERTEX_SHADER, "vertex_shader");
	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment_vert_shader");
	vProgram = glCreateProgram();
	glAttachShader(vProgram, vShader);
	glAttachShader(vProgram, fShader);
	glLinkProgram(vProgram);

	int link_res;
	glGetProgramiv(vProgram, GL_LINK_STATUS, &link_res);

	Attrib_vertex = glGetAttribLocation(vProgram, "coord");
	Unif_v_color1 = glGetUniformLocation(vProgram, "v_color1");
	Unif_v_color2 = glGetUniformLocation(vProgram, "v_color2");
	Unif_v_lines = glGetUniformLocation(vProgram, "lines");
}


//загрузить шейдеры дл€ горизонтально заштрихованного изображени€
void initHorShader()
{
	GLuint vShader, fShader;
	vShader = load_shader(GL_VERTEX_SHADER, "vertex_shader");
	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment_hor_shader");
	hProgram = glCreateProgram();
	glAttachShader(hProgram, vShader);
	glAttachShader(hProgram, fShader);
	glLinkProgram(hProgram);
	int link_res;
	glGetProgramiv(hProgram, GL_LINK_STATUS, &link_res);

	Attrib_vertex = glGetAttribLocation(hProgram, "coord");
	Unif_h_color1 = glGetUniformLocation(hProgram, "h_color1");
	Unif_h_color2 = glGetUniformLocation(hProgram, "h_color2");
	Unif_h_lines = glGetUniformLocation(hProgram, "lines");
}

//удалить скомпилированные с шейдерами программы
void freeShader() {
	glUseProgram(0);
	glDeleteProgram(Program);
	glDeleteProgram(vProgram);
	glDeleteProgram(hProgram);
}

void init(void) {
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glEnable(GL_DEPTH_TEST);
}

void reshape(int w, int h) {
	width = w; height = h;
	glViewport(0, 0, w, h);
}

void display(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	
	if (IMG_IDX == 1)
	{
		glUseProgram(Program);
		static float red[4] = { 1.0f, 0.0f, 0.0f, 1.0f };
		glUniform4fv(Unif_color, 1, red);
	}
	else if (IMG_IDX == 2)
	{
		glUseProgram(vProgram);
		glUniform4fv(Unif_v_color1, 1, v_color1);
		glUniform4fv(Unif_v_color2, 1, v_color2);
		glUniform1i(Unif_v_lines, ver_line);
	}
   else if (IMG_IDX == 3)
	{
		glUseProgram(hProgram);
		glUniform4fv(Unif_h_color1, 1, h_color1);
		glUniform4fv(Unif_h_color2, 1, h_color2);
		glUniform1i(Unif_h_lines, hor_line);
	}

	glBegin(GL_QUADS);
	glColor3f(1.0, 0.0, 0.0); glVertex2f(-0.5f, -0.5f);
	glColor3f(0.0, 1.0, 0.0); glVertex2f(-0.5f, 0.5f);
	glColor3f(0.0, 0.0, 1.0); glVertex2f(0.5f, 0.5f);
	glColor3f(1.0, 1.0, 1.0); glVertex2f(0.5f, -0.5f);  
	glEnd();
	glFlush();

	glUseProgram(0);

	glutSwapBuffers();
}

void keyboard_mapping(unsigned char key, int x, int y)
{
	switch (key)
	{
	case '1': IMG_IDX = 1;
		break;
	case '2':
		IMG_IDX = 2;
		break;
	case '3':
		IMG_IDX = 3;
		break;
	case '=':
		if (IMG_IDX == 2)
			++ver_line;
		else ++hor_line;
		break;
	case '-':
		if (IMG_IDX == 2)
			--ver_line;
		else --hor_line;
		break;
	}
	glutPostRedisplay();
}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(800, 800);
	glutInitWindowPosition(10, 10);
	glutCreateWindow("Lab 12");

	GLenum glew_status = glewInit();

	initShader();
	initVertShader();
	initHorShader();
	init();
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard_mapping);
	glutMainLoop();

	freeShader();
}