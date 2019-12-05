#include <freeglut.h>

using namespace std;

static int Width = 800, Height = 600;

double rotate_x = 0, rotate_y = 0, rotate_z = 0;

bool isOrthoProjection = true;

int rotationMode = 0;

float centerX = 1.25, centerY = 0.25, centerZ = 0.25;

//Функция вызываемая при изменении размеров окна
void Reshape(int width, int height) {
	Width = width;
	Height = height;
}

//Функция вызываемая каждый кадр - для его отрисовки, вычислений и т. д.
void Update(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	if (isOrthoProjection) {
		glOrtho(-2.0, 2.0, -2.0, 2.0, -2.0, 2.0);
	}
	else {
		gluPerspective(100.0, Width/Height, 0.0, 500.0);
		gluLookAt(1.0, 0.5, 2.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);	
	}

	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	//transfer from the scene center
	glTranslatef(1.0, 0.0, 0.0);

	switch (rotationMode)
	{
	case 0:  //around center of the scene
		glTranslatef(-centerX, -centerY, -centerZ);
		glRotatef(rotate_x, 1.0, 0.0, 0.0);
		glRotatef(rotate_y, 0.0, 1.0, 0.0);
		glRotatef(rotate_z, 0.0, 0.0, 1.0);
		glTranslatef(centerX, centerY, centerZ);
		break;
	case 1:  //around center of the pedestal
		glRotatef(rotate_x, 1.0, 0.0, 0.0);
		glRotatef(rotate_y, 0.0, 1.0, 0.0);
		glRotatef(rotate_z, 0.0, 0.0, 1.0);
		break;
	case 2:
		break;
	default:
		glTranslatef(-centerX, -centerY, -centerZ);
		glRotatef(rotate_x, 1.0, 0.0, 0.0);
		glRotatef(rotate_y, 0.0, 1.0, 0.0);
		glRotatef(rotate_z, 0.0, 0.0, 1.0);
		glTranslatef(centerX, centerY, centerZ);
		break;
	}

	if (rotationMode == 2) {
		glPushMatrix();
		glRotatef(rotate_x, 1.0, 0.0, 0.0);
		glRotatef(rotate_y, 0.0, 1.0, 0.0);
		glRotatef(rotate_z, 0.0, 0.0, 1.0);
	}

	//first place
	glColor3f(1.0, 0.8431, 0.0);
	glutWireCube(0.5);
	if (rotationMode == 2)
		glPopMatrix();

	//third place
	glColor3f(0.80, 0.49, 0.19);
	glScalef(1.0, 0.5, 1.0);
	glTranslatef(0.5, -0.25, 0.0);
	if (rotationMode == 2) {
		glPushMatrix();
		glRotatef(rotate_x, 1.0, 0.0, 0.0);
		glRotatef(rotate_y, 0.0, 1.0, 0.0);
		glRotatef(rotate_z, 0.0, 0.0, 1.0);
	}
	glutWireCube(0.5);
	if (rotationMode == 2)
		glPopMatrix();
	glTranslatef(-0.5, 0.25, 0.0);
	glScalef(1.0, 2.0, 1.0);

	//second place
	glColor3f(0.75, 0.75, 0.75);
	glScalef(1.0, 0.7, 1.0);
	glTranslatef(-0.5, -0.105, 0.0);
	if (rotationMode == 2) {
		glPushMatrix();
		glRotatef(rotate_x, 1.0, 0.0, 0.0);
		glRotatef(rotate_y, 0.0, 1.0, 0.0);
		glRotatef(rotate_z, 0.0, 0.0, 1.0);
	}
	glutWireCube(0.5);
	if (rotationMode == 2)
		glPopMatrix();
	glTranslatef(0.5, 0.105, 0.0);
	glScalef(1.0, 1.4, 1.0);

	glFlush();
	glutSwapBuffers();
}

void SpecialKeys(int key, int x, int y) {
	switch (key) {
	case GLUT_KEY_UP: rotate_x += 5; break;
	case GLUT_KEY_DOWN: rotate_x -= 5; break;
	case GLUT_KEY_RIGHT: rotate_y += 5; break;
	case GLUT_KEY_LEFT: rotate_y -= 5; break;
	case GLUT_KEY_PAGE_UP: rotate_z += 5; break;
	case GLUT_KEY_PAGE_DOWN: rotate_z -= 5; break;
	case GLUT_KEY_CTRL_R: isOrthoProjection = !isOrthoProjection; break;
	case GLUT_KEY_F1: rotationMode = 0; rotate_x = 0; rotate_y = 0; rotate_z = 0; break; //around center of the scene
	case GLUT_KEY_F2: rotationMode = 1; rotate_x = 0; rotate_y = 0; rotate_z = 0; break; //around center of the pedestal 
	case GLUT_KEY_F3: rotationMode = 2; rotate_x = 0; rotate_y = 0; rotate_z = 0; break; //each cube around its axis 
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
	glutKeyboardFunc(KeyboardHandler);
	glutSpecialFunc(SpecialKeys);
	//войти в главный цикл приложения
	glutMainLoop();
}