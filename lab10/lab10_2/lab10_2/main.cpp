#include <freeglut.h>
#include <random>
#include <tuple>

using namespace std;

static int Width = 800, Height = 600;

double rotate_x = 0, rotate_y = 0, rotate_z = 0;

class Point2D {
public:
	float x;
	float y;
	Point2D(float xx = 0, float yy = 0) : x(xx), y(yy) {}
};

//Функция вызываемая при изменении размеров окна
void Reshape(int width, int height) {
	Width = width;
	Height = height;
}

//Функция вызываемая каждый кадр - для его отрисовки, вычислений и т. д.
void Update(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glRotatef(10, 1.0, 1.0, 0.0);

	//first
	glColor3f(1.0, 0.8431, 0.0);
	glutWireCube(0.5);

	//second
	glColor3f(0.80, 0.49, 0.19);
	glScalef(1.0, 0.5, 1.0);
	glTranslatef(0.5, -0.25, 0.0);
	glutWireCube(0.5);
	glTranslatef(-0.5, 0.25, 0.0);
	glScalef(1.0, 2.0, 1.0);

	//third
	glColor3f(0.75, 0.75, 0.75);
	glScalef(1.0, 0.7, 1.0);
	glTranslatef(-0.5, -0.105, 0.0);
	glutWireCube(0.5);
	glTranslatef(0.5, 0.105, 0.0);
	glScalef(1.0, 1.4, 1.0);

	glFlush();
	glutSwapBuffers();}

void MouseHandler(int button, int state, int x, int y) {
	if (state == GLUT_UP) {
		switch (button) {
		case GLUT_LEFT_BUTTON:
			glutPostRedisplay();
			break;
		case GLUT_RIGHT_BUTTON:
			break;
		}
	}
}

void SpecialKeys(int key, int x, int y) {
	switch (key) {
	case GLUT_KEY_UP: rotate_x += 5; break;
	case GLUT_KEY_DOWN: rotate_x -= 5; break;
	case GLUT_KEY_RIGHT: rotate_y += 5; break;
	case GLUT_KEY_LEFT: rotate_y -= 5; break;
	case GLUT_KEY_PAGE_UP: rotate_z += 5; break;
	case GLUT_KEY_PAGE_DOWN: rotate_z -= 5; break;
	}
	glutPostRedisplay();
}

void KeyboardHandler(unsigned char key, int x, int y) {
#define ESCAPE '\033'
	if (key == ESCAPE)
		exit(0);
}

int main(int argc, char* argv[]) {
	//инициализировать сам glut
	glutInit(&argc, argv);
	//установить начальное положение окна
	glutInitWindowPosition(300, 100);
	//установить начальные размеры окна
	glutInitWindowSize(Width, Height);
	//установить параметры окна - двойная буфферизация и поддержка цвета rgba
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	//создать окно с заголовком opengl
	glutCreateWindow("Lab10/part2");
	//укажем glut функцию, которая будет вызываться при изменении размера окна приложения
	glutReshapeFunc(Reshape);
	//укажем glut функцию, которая будет рисовать каждый кадр
	glutDisplayFunc(Update);
	//glutMouseFunc(MouseHandler);
	glutKeyboardFunc(KeyboardHandler);
	//glutSpecialFunc(SpecialKeys);
	//войти в главный цикл приложения
	glutMainLoop();
}