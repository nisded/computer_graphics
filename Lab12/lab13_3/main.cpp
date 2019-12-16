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

#include <SOIL.h>
#include <glm/gtc/matrix_transform.hpp>

unsigned char* image;
GLuint texture1, texture2;
int width = 0, height = 0;
int IMG_IDX = 1;
GLuint Programs [3];
GLint Unif_tex_1, Unif_tex_2, Unif_coef;
GLuint VBO, VAO, IBO;
std::vector<GLushort> indices;
float coef = 0.5f;

void makeTextureImage()
{
	texture1 = SOIL_load_OGL_texture
	(
		"gabe.jpg",
		SOIL_LOAD_AUTO,
		SOIL_CREATE_NEW_ID,
		SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT
	);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
	texture2 = SOIL_load_OGL_texture
	(
		"texture.jpg",
		SOIL_LOAD_AUTO,
		SOIL_CREATE_NEW_ID,
		SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT
	);
}

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

//загрузка шейдеров для i-го изображения (i = 1..3)
void init_shaders(int i) {
	std::string readed = read_shader("vertex.shader");
	const char* vsSource = readed.c_str();

	std::string readed2 = read_shader("fragment" + std::to_string(i) + ".shader");
	const char* fsSource = readed2.c_str();

	GLuint vShader, fShader;
	vShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vShader, 1, &vsSource, NULL);
	glCompileShader(vShader);

	fShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fShader, 1, &fsSource, NULL);
	glCompileShader(fShader);

	Programs[i - 1] = glCreateProgram();
	glAttachShader(Programs[i - 1], vShader);
	glAttachShader(Programs[i - 1], fShader);
	glLinkProgram(Programs[i - 1]);

	int link_ok;
	glGetProgramiv(Programs[0], GL_LINK_STATUS, &link_ok);
}

//загрузка шейдеров для третьего изображения + получение данных о текстуре
void initShader3() {
	init_shaders(3);
	Unif_tex_1 = glGetUniformLocation(Programs[2], "ourTexture1");
	Unif_tex_2 = glGetUniformLocation(Programs[2], "ourTexture2");
	Unif_coef = glGetUniformLocation(Programs[2], "coef");
}

void freeShader() {
	glUseProgram(0);
	glDeleteProgram(Programs[0]);
	glDeleteProgram(Programs[1]);
	glDeleteProgram(Programs[2]);
}

void init(void)
{
	glClearColor(0.0, 0.0, 0.0, 0.0);

	glEnable(GL_DEPTH_TEST);
}

void reshape(int w, int h)
{
	width = w; height = h;
	glViewport(0, 0, w, h);
}

void initBuffers()
{
	GLfloat vertices[] = {
		 0.5,  0.5, 0, 1, 0, 0,  1, 1,
		 0.5, -0.5, 0, 0, 1, 0,  1, 0,
		-0.5, -0.5, 0, 0, 0, 1,  0, 0,
		-0.5,  0.5, 0, 1, 1, 0,  0, 1
	};

	indices = { 0, 1, 2, 3 };

	glGenBuffers(1, &VBO);
	glGenVertexArrays(1, &VAO);
	glGenBuffers(1, &IBO);

	glBindVertexArray(VAO);

	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, IBO);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, indices.size() * sizeof(GLushort), &indices[0], GL_STATIC_DRAW);

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glEnableVertexAttribArray(0);
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glEnableVertexAttribArray(1);
	glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));
	glEnableVertexAttribArray(2);

	glBindVertexArray(0);
}

void display(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	glEnable(GL_TEXTURE_2D);

	if (IMG_IDX == 1) {
		glUseProgram(Programs[0]);
		glBindTexture(GL_TEXTURE_2D, texture1);
	}
	else if (IMG_IDX == 2) {
		glUseProgram(Programs[1]);
		glBindTexture(GL_TEXTURE_2D, texture1);
	}
	else if (IMG_IDX == 3) {
		glUseProgram(Programs[2]);
		glActiveTexture(GL_TEXTURE0);
		glBindTexture(GL_TEXTURE_2D, texture1);
		glUniform1i(Unif_tex_1, 0);
		glActiveTexture(GL_TEXTURE1);
		glBindTexture(GL_TEXTURE_2D, texture2);
		glUniform1i(Unif_tex_2, 1);
		glUniform1f(Unif_coef, coef);
	}

	glBindVertexArray(VAO);
	glDrawElements(GL_QUADS, 4, GL_UNSIGNED_SHORT, 0);
	glBindVertexArray(0);

	glUseProgram(0);
	glDisable(GL_TEXTURE_2D);
	glutSwapBuffers();
}

void special_keys_mapping(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_F1: IMG_IDX = 1;
		break;
	case GLUT_KEY_F2:
		IMG_IDX = 2;
		break;
	case GLUT_KEY_F3:
		IMG_IDX = 3;
		break;
	}
	glutPostRedisplay();
}


void keyboard_mapping(unsigned char key, int x, int y)
{
	switch (key)
	{
	case '1': coef = 0.1f;
		break;
	case '2':
		coef = 0.2f;
		break;
	case '3':
		coef = 0.3f;
		break;
	case '4':
		coef = 0.4f;
		break;
	case '5':
		coef = 0.5f;
		break;
	case '6':
		coef = 0.6f;
		break;
	case '7':
		coef = 0.7f;
		break;
	case '8':
		coef = 0.8f;
		break;
	case '9':
		coef = 0.9f;
		break;
	case '0':
		coef = 0.0f;
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
	initBuffers();
	makeTextureImage();
	init_shaders(1);
	init_shaders(2);
	initShader3();
	init();
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard_mapping);
	glutSpecialFunc(special_keys_mapping);
	glutMainLoop();

	freeShader();
}