#include"GL/glew.h"
#include"GL/freeglut.h"
#include<string>
#include<fstream>

#include<glm/gtc/matrix_transform.hpp>

int width = 0, height = 0;
//1 - сплошная заливка, 2 - заливка горизонт. штрих-кой, 3 - заливка вертикал. штрих-кой
int fill_mode = 1;

GLint Attrib_vertex, Unif_color;
GLint Unif_h_color1, Unif_h_color2, Unif_h_line_witdh;
GLint Unif_v_color1, Unif_v_color2, Unif_v_line_witdh;
GLuint Program, hProgram, vProgram;

float h_color1[]{ 0, 0, 1, 1 };
float h_color2[]{ 0, 1, 0, 1 };
int hor_line_width = 35;

float v_color1[]{ 0, 0, 1, 1 };
float v_color2[]{ 0, 1, 0, 1 };
int ver_line_width = 35;

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

//загрузить шейдеры для закрашенного изображения
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

	Attrib_vertex = glGetAttribLocation(Program, "coord");
	Unif_color = glGetUniformLocation(Program, "color");
}

//загрузить шейдеры для горизонтально заштрихованного изображения
void initHorShader()
{
	GLuint vShader, fShader;
	vShader = load_shader(GL_VERTEX_SHADER, "vertex_shader");
	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment_hor_shader");

	hProgram = glCreateProgram();
	glAttachShader(hProgram, vShader);
	glAttachShader(hProgram, fShader);
	glLinkProgram(hProgram);

	glDeleteShader(vShader);
	glDeleteShader(fShader);

	Attrib_vertex = glGetAttribLocation(hProgram, "coord");
	Unif_h_color1 = glGetUniformLocation(hProgram, "h_color1");
	Unif_h_color2 = glGetUniformLocation(hProgram, "h_color2");
	Unif_h_line_witdh = glGetUniformLocation(hProgram, "line_width");
}

//загрузить шейдеры для вертикально заштрихованного изображения
void initVertShader() {
	GLuint vShader, fShader;
	vShader = load_shader(GL_VERTEX_SHADER, "vertex_shader");
	fShader = load_shader(GL_FRAGMENT_SHADER, "fragment_vert_shader");

	vProgram = glCreateProgram();
	glAttachShader(vProgram, vShader);
	glAttachShader(vProgram, fShader);
	glLinkProgram(vProgram);

	glDeleteShader(vShader);
	glDeleteShader(fShader);

	Attrib_vertex = glGetAttribLocation(vProgram, "coord");
	Unif_v_color1 = glGetUniformLocation(vProgram, "v_color1");
	Unif_v_color2 = glGetUniformLocation(vProgram, "v_color2");
	Unif_v_line_witdh = glGetUniformLocation(vProgram, "line_width");
}

//удалить скомпилированные с шейдерами программы
void freeShader() {
	glUseProgram(0);
	glDeleteProgram(Program);
	glDeleteProgram(hProgram);
	glDeleteProgram(vProgram);
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

	if (fill_mode == 1)
	{
		glUseProgram(Program);
		static float red[4] = { 1.0f, 0.0f, 0.0f, 1.0f };
		glUniform4fv(Unif_color, 1, red);
	}
	else if (fill_mode == 2)
	{
		glUseProgram(hProgram);
		glUniform4fv(Unif_h_color1, 1, h_color1);
		glUniform4fv(Unif_h_color2, 1, h_color2);
		glUniform1i(Unif_h_line_witdh, hor_line_width);
	}
	else if (fill_mode == 3)
	{
		glUseProgram(vProgram);
		glUniform4fv(Unif_v_color1, 1, v_color1);
		glUniform4fv(Unif_v_color2, 1, v_color2);
		glUniform1i(Unif_v_line_witdh, ver_line_width);
	}

	glBegin(GL_QUADS);
	glVertex2f(-0.5f, -0.5f);
	glVertex2f(-0.5f, 0.5f);
	glVertex2f(0.5f, 0.5f);
	glVertex2f(0.5f, -0.5f);
	glEnd();

	glFlush();

	glUseProgram(0);

	glutSwapBuffers();
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key)
	{
	case '1': fill_mode = 1;
		break;
	case '2':
		fill_mode = 2;
		break;
	case '3':
		fill_mode = 3;
		break;
	case '=':
		if (fill_mode == 2)
			++hor_line_width;
		else
			++ver_line_width;
		break;
	case '-':
		if (fill_mode == 2)
			--hor_line_width;
		else
			--ver_line_width;
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
	glutCreateWindow("Lab12/task2");

	glewInit();
	initShader();
	initHorShader();
	initVertShader();
	init();

	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(keyboard);
	glutMainLoop();

	freeShader();
}