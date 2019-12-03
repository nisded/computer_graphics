#include <freeglut.h>
#include <random>
#include <tuple>

using namespace std;

static int Width = 600, Height = 400;

// 0-rectangle, 1-multi-colored rectangle, 2-triangle, 3-multi-colored triangle
int figureInd = 0;

double rotate_x = 0, rotate_y = 0, rotate_z = 0;

class Point2D {
public:
	float x;
	float y;
	Point2D(float xx = 0, float yy = 0): x(xx), y(yy) {}
};

//Функция вызываемая при изменении размеров окна
void Reshape(int width, int height) {
	Width = width;
	Height = height;
}

Point2D randomPoint() {
	random_device rd;    // only used once to initialise (seed) engine
	mt19937 rng(rd());
	uniform_real_distribution<float> uni(-1, 1);
	return  Point2D(uni(rng), uni(rng));
}

tuple<float, float, float> randomColor() {
	random_device rd; 
	mt19937 rng(rd());
	uniform_real_distribution<float> uni(0, 1);
	return  { uni(rng), uni(rng), uni(rng) };
}

void DrawTriangle(bool multicol = 0) {
	Point2D a = randomPoint();
	Point2D b = randomPoint();
	Point2D c = randomPoint();
	glBegin(GL_TRIANGLES);
	if (!multicol) {
		glVertex2f(a.x, a.y);
		glVertex2f(b.x, b.y);
		glVertex2f(c.x, c.y);
	}
	else {
		glVertex2f(a.x, a.y);

		auto randClr = randomColor();
		float r, g, bl;
		tie(r, g, bl) = randClr;
		glColor3f(r, g, bl);

		glVertex2f(b.x, b.y);

		randClr = randomColor();
		tie(r, g, bl) = randClr;
		glColor3f(r, g, bl);

		glVertex2f(c.x, c.y);
	}
	glEnd();
}

void DrawRect(bool multicol = 0) {
	Point2D a = randomPoint();
	Point2D b = randomPoint();

	glBegin(GL_QUADS);
	if (!multicol) {
		glVertex2f(a.x, a.y);
		glVertex2f(b.x, a.y);
		glVertex2f(b.x, b.y);
		glVertex2f(a.x, b.y);
	}
	else {
		glVertex2f(a.x, a.y);

		auto randClr = randomColor();
		float r, g, bl;
		tie(r, g, bl) = randClr;
		glColor3f(r, g, bl);

		glVertex2f(b.x, a.y);

		randClr = randomColor();
		tie(r, g, bl) = randClr;
		glColor3f(r, g, bl);

		glVertex2f(b.x, b.y);

		randClr = randomColor();
		tie(r, g, bl) = randClr;
		glColor3f(r, g, bl);

		glVertex2f(a.x, b.y);
	}
	glEnd();
}

//Функция вызываемая каждый кадр - для его отрисовки, вычислений и т. д.
void Update(void) {
	glClear(GL_COLOR_BUFFER_BIT);

	glLoadIdentity();
	glRotatef(rotate_x, 1.0, 0.0, 0.0);
	glRotatef(rotate_y, 0.0, 1.0, 0.0);
	glRotatef(rotate_z, 0.0, 0.0, 1.0);
	auto randClr = randomColor();
	float r, g, bl;
	tie(r, g, bl) = randClr;
	glColor3f(r, g, bl);

	if (figureInd > 3)
		figureInd = 0;

	/*glBegin(GL_QUADS);
	glVertex2f(-0.5f, -0.5f);
	glColor3f(0.0, 1.0, 0.0); 
	glVertex2f(-0.5f, 0.5f);
	glColor3f(0.0, 0.0, 1.0); 
	glVertex2f(0.5f, 0.5f);
	glColor3f(1.0, 1.0, 1.0); 
	glVertex2f(0.5f, -0.5f);
	glEnd();*/

	switch (figureInd)
	{
	case 0:	
		DrawRect();
		break;
	case 1:
		DrawRect(1);
		break;
	case 2:	
		DrawTriangle();
		break;
	case 3:
		DrawTriangle(1);
		break;
	default:
		DrawTriangle();
		break;
	}

	glFlush();
	glutSwapBuffers();}

void MouseHandler(int button, int state, int x, int y) {
	if(state == GLUT_UP) {
		switch(button) {
			case GLUT_LEFT_BUTTON:
				glutPostRedisplay();
				break;
			case GLUT_RIGHT_BUTTON:
				++figureInd;
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

int main(int argc, char *argv[]) {
	//инициализировать сам glut
	glutInit(&argc, argv);
	//установить начальное положение окна
	glutInitWindowPosition(300, 100);
	//установить начальные размеры окна
	glutInitWindowSize(Width, Height);
	//установить параметры окна - двойная буфферизация и поддержка цвета rgba
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	//создать окно с заголовком opengl
	glutCreateWindow("Lab10/part1");
	//укажем glut функцию, которая будет вызываться при изменении размера окна приложения
	glutReshapeFunc(Reshape);
	//укажем glut функцию, которая будет рисовать каждый кадр
	glutDisplayFunc(Update);
	glutMouseFunc(MouseHandler);
	glutKeyboardFunc(KeyboardHandler);
	glutSpecialFunc(SpecialKeys);
	//войти в главный цикл приложения
	glutMainLoop();
}