#include"GL/glew.h"
#include"GL/freeglut.h"
#include<SOIL.h>
#include<string>
#include<fstream>
#include<glm/gtc/matrix_transform.hpp>

GLuint texture1, texture2;
int width = 0, height = 0;
//1 - наложить 1 текстуру, 2 - смешать текстуру с цветом, 3 - наложить 2 текстуры с некоторым коэффициентом смешивания
int texturing_mode = 1;
GLuint Programs[3];
GLint Unif_tex_1, Unif_tex_2, Unif_coef;
GLuint VBO, VAO, IBO;
float coef = 0.5f;

void loadTextureImages() {
	texture1 = SOIL_load_OGL_texture
	(
		"../textures/mona_lisa.jpg",
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
		"../textures/bw_texture.jpg",
		SOIL_LOAD_AUTO,
		SOIL_CREATE_NEW_ID,
		SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT
	);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
}

std::string read_shader(std::string path) {
	std::string res = "";
	std::ifstream file(path);
	std::string line;
	getline(file, res, '\n');
	while (getline(file, line)) {
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

void init_shaders() {
	GLuint vShader, fShader;
	vShader = load_shader(GL_VERTEX_SHADER, "vertex.shader");
	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment1.shader");

	Programs[0] = glCreateProgram();
	glAttachShader(Programs[0], vShader);
	glAttachShader(Programs[0], fShader);
	glLinkProgram(Programs[0]);
	glDeleteShader(fShader);

	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment2.shader");

	Programs[1] = glCreateProgram();
	glAttachShader(Programs[1], vShader);
	glAttachShader(Programs[1], fShader);
	glLinkProgram(Programs[1]);
	glDeleteShader(fShader);

	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment3.shader");

	Programs[2] = glCreateProgram();
	glAttachShader(Programs[2], vShader);
	glAttachShader(Programs[2], fShader);
	glLinkProgram(Programs[2]);
	glDeleteShader(vShader);
	glDeleteShader(fShader);

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

void init(void) {
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glEnable(GL_DEPTH_TEST);
}

void reshape(int w, int h) {
	width = w; height = h;
	glViewport(0, 0, w, h);
}

void initBuffers() {
	//position[3], color[3], texCoord[2]
	GLfloat vertices[] = {
		-0.5, -0.5, 0, 1, 0, 0,  0, 0,
		-0.5,  0.5, 0, 0, 1, 0,  0, 1,
		 0.5,  0.5, 0, 0, 0, 1,  1, 1,
		 0.5, -0.5, 0, 0, 0, 0,  1, 0
	};

	GLuint indices[] = { 0, 1, 2, 3 };

	glGenBuffers(1, &VBO);
	glGenBuffers(1, &IBO);
	glGenVertexArrays(1, &VAO);

	glBindVertexArray(VAO);

	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, IBO);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glEnableVertexAttribArray(0);
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glEnableVertexAttribArray(1);
	glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));
	glEnableVertexAttribArray(2);

	glBindVertexArray(0);
}

void display(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	glEnable(GL_TEXTURE_2D);

	if (texturing_mode == 1) {
		glUseProgram(Programs[0]);
		glBindTexture(GL_TEXTURE_2D, texture1);
	}
	else if (texturing_mode == 2) {
		glUseProgram(Programs[1]);
		glBindTexture(GL_TEXTURE_2D, texture1);
	}
	else if (texturing_mode == 3) {
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
	glDrawElements(GL_QUADS, 4, GL_UNSIGNED_INT, 0);
	glBindVertexArray(0);

	glUseProgram(0);
	glDisable(GL_TEXTURE_2D);
	glutSwapBuffers();
}

void special_keys(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_F1:
		texturing_mode = 1;
		break;
	case GLUT_KEY_F2:
		texturing_mode = 2;
		break;
	case GLUT_KEY_F3:
		texturing_mode = 3;
		break;
	}
	glutPostRedisplay();
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key)
	{
	case '1':
		coef = 0.1f;
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

int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(10, 10);
	glutCreateWindow("Lab12/task3");

	glewInit();
	init();
	loadTextureImages();
	init_shaders();
	initBuffers();

	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard);
	glutSpecialFunc(special_keys);
	glutMainLoop();

	freeShader();
}