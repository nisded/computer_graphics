#include <iostream>
#include <cmath>
#include <freeglut.h>

#pragma comment (lib , "freeglut.lib")

//хранят текущий размер экрана
static int w = 0, h = 0;
// видид проекции
static bool p = false;
// Углы вращения
static double rotate_x = 0;
static double rotate_y = 0;
static double rotate_z = 0;


//Функция вызываемая перед вхождением в главный цикл
void Init(void) {
	glClearColor(0.0f, 0.0f, 1.0f, 1.0f);
}

//Функция рисует дерево, отступая на x, y, z от начала координат
void drawTree(double x, double y, double z)
{
	glLoadIdentity();
	glTranslated(x, y, z);

	GLUquadricObj *quadratic = gluNewQuadric();
	glColor3ub(101, 67, 33);
	gluCylinder(quadratic, 0.03, 0.03, 0.15, 100, 1);
	glTranslated(0.0, 0.0, 0.15);
	glColor3ub(0, 160, 0);
	glutSolidCone(0.15, 0.25, 100, 1);
	glTranslated(0.0, 0.0, 0.25);
	glutSolidCone(0.10, 0.20, 100, 1);
	glTranslated(0.0, 0.0, 0.20);
	glutSolidCone(0.05, 0.15, 100, 1);

	glTranslated(-x, -y, -z);
}

//Функция вызываемая каждый кадр -
// для его отрисовки, вычислений и т. д.
void Update(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	
	drawTree(-1.0, 1.0, 0.0);
	drawTree(1.0, -1.0, 0.0);
	drawTree(-0.5, 1.0, 0.0);
	drawTree(1.0, -0.5, 0.0);
	drawTree(1.0, 0.0, 0.0);
	drawTree(0.0, 1.0, 0.0);
	drawTree(0.5, 1.0, 0.0);
	drawTree(1.0, 0.5, 0.0);
	drawTree(1.0, 1.0, 0.0);
	
	drawTree(-0.5, -0.5, 0.0);
	drawTree(0.5, -0.5, 0.0);
	drawTree(-0.5, 0.5, 0.0);
	drawTree(-0.5, 0.0, 0.0);
	drawTree(0.0, -0.5, 0.0);
	drawTree(0.0, 0.0, 0.0);
	drawTree(0.5, 0.0, 0.0);
	drawTree(0.0, 0.5, 0.0);
	drawTree(0.5, 0.5, 0.0);
	
	drawTree(0.5, -1.0, 0.0);
	drawTree(-1.0, 0.5, 0.0);
	drawTree(0.0, -1.0, 0.0);
	drawTree(-1.0, 0.0, 0.0);
	drawTree(-0.5, -1.0, 0.0);
	drawTree(-1.0, -0.5, 0.0);
	drawTree(-1.0, -1.0, 0.0);
	
	glFlush();
	glutSwapBuffers();
	
	if (!p)
	{
		glMatrixMode(GL_PROJECTION);
		glLoadIdentity();
		glOrtho(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f);
	}
	else
	{
		glMatrixMode(GL_PROJECTION);
		glLoadIdentity();
		gluPerspective(100.0f, 1, 0.0f, 5000.f);
		gluLookAt(1.5f, 1.5f, 1.0f, 0.5f, 0.5f, 0.5f, 1.0f, 1.0f, 1.5f);
	}

	glRotatef(rotate_x, 1.0, 0.0, 0.0);
	glRotatef(rotate_y, 0.0, 1.0, 0.0);
	glRotatef(rotate_z, 0.0, 0.0, 1.0);
}

//Функция обработки клавиатуры
void processNormalKeys(int key, int x, int y) {
	if (key == GLUT_KEY_LEFT) rotate_y -= 5;
	else if (key == GLUT_KEY_RIGHT) rotate_y += 5;
	else if (key == GLUT_KEY_UP) rotate_x += 5;
	else if (key == GLUT_KEY_DOWN) rotate_x -= 5;
	else if (key == GLUT_KEY_PAGE_UP) rotate_z += 5;
	else if (key == GLUT_KEY_PAGE_DOWN) rotate_z -= 5;
	else if (key == GLUT_KEY_HOME)
	{
		p = true;
		rotate_x = 0.0;
		rotate_y = 0.0;
		rotate_z = 0.0;
	}
	else if (key == GLUT_KEY_END)
	{
		p = false;
		rotate_x = 0.0;
		rotate_y = 0.0;
		rotate_z = 0.0;
	}

	glutPostRedisplay();
}

//Функця вызываемая при изменении размеров окна
void Reshape(int width, int height) {
	w = width; h = height;

	glViewport(0, 0, w, h);
}

int main(int argc, char * argv[]) {
	//Инициализировать сам glut
	glutInit(&argc, argv);
	//Установить начальное положение окна
	glutInitWindowPosition(100, 100);
	//Установить начальные размеры окна
	glutInitWindowSize(600, 600);
	//Установить параметры окна - двойная буфферизация
	// и поддержка цвета RGBA
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	//Создать окно с заголовком OpenGL
	glutCreateWindow("Вывод 3D-объектов");

	//Укажем glut функцию, которая будет вызываться каждый кадр
	glutIdleFunc(Update);
	//Укажем glut функцию, которая будет рисовать каждый кадр
	glutDisplayFunc(Update);
	//Укажем glut функцию, которая будет вызываться при
	// изменении размера окна приложения
	glutReshapeFunc(Reshape);
	// Функция обработки клавиш окна
	glutSpecialFunc(processNormalKeys);
	Init();
	//Войти в главный цикл приложения
	glutMainLoop();
	return 0;
}