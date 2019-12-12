#include "soil.h"
#include "freeglut.h"

#include <iostream>

static int w = 0, h = 0;

GLuint floor_texture_id;
GLuint body_texture_id;
GLuint cabin_texture_id;

GLfloat cam_dist = 25;
GLfloat ang_hor = 0, ang_vert = 60;
double cam_x = 0;
double cam_y = 0;
double cam_z = 0;

GLfloat no_light[] = { 0, 0, 0, 1 };
GLfloat light[] = { 1, 1, 1, 0 };

GLfloat dist_x = 0, dist_y = 0;
GLfloat angle = 0;

void updateCamera() {
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(60.f, (float)w / h, 1.0f, 1000.f);
	glMatrixMode(GL_MODELVIEW);
}


void reshape(int width, int height) {
	w = width;
	h = height;

	glViewport(0, 0, w, h);
	updateCamera();
}


void loadTextures() {
	floor_texture_id = SOIL_load_OGL_texture("..\\..\\textures\\road-stone-texture.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID,
		SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);

	body_texture_id = SOIL_load_OGL_texture("..\\..\\textures\\metal-texture.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID,
		SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);

	cabin_texture_id = SOIL_load_OGL_texture("..\\..\\textures\\rust-texture.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID,
		SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
}

void init() {
	glClearColor(0, 0, 0, 1);

	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	loadTextures();

	const GLfloat light_diffuse[] = { 1.0, 1.0, 1.0, 1.0 };
	const GLfloat light_specular[] = { 1.0, 1.0, 1.0, 1.0 };

	glLightfv(GL_LIGHT1, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT1, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT2, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT2, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT3, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT3, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT4, GL_DIFFUSE, light_diffuse);

	glLightfv(GL_LIGHT5, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT5, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT6, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT6, GL_DIFFUSE, light_diffuse);

	glLightfv(GL_LIGHT7, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT7, GL_DIFFUSE, light_diffuse);
	const GLfloat direction[] = { 0.0, 0.0, -1.0 };
	glLightfv(GL_LIGHT7, GL_SPOT_DIRECTION, direction);
	glLightf(GL_LIGHT7, GL_SPOT_CUTOFF, 40.0);
	glLightf(GL_LIGHT7, GL_SPOT_EXPONENT, 0.0);


	glEnable(GL_DEPTH_TEST);
	glEnable(GL_COLOR_MATERIAL);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);

}

void drawFloor() {
	glEnable(GL_TEXTURE_2D);
	glTexEnvf(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);
	glBindTexture(GL_TEXTURE_2D, floor_texture_id);

	glBegin(GL_QUADS);
	glTexCoord2f(0, 0); glNormal3f(0, 0, 1); glVertex3f(-10, -10, 0);
	glTexCoord2f(0, 1); glNormal3f(0, 0, 1); glVertex3f(-10, 10, 0);
	glTexCoord2f(1, 1); glNormal3f(0, 0, 1); glVertex3f(10, 10, 0);
	glTexCoord2f(1, 0); glNormal3f(0, 0, 1); glVertex3f(10, -10, 0);
	glEnd();

	glDisable(GL_TEXTURE_2D);
}


void drawLamps() {
	const GLfloat light_pos[] = { 0.0f, 0.0f, 4.5f, 1.0f };
	glColor3f(0.5f, 0.5f, 0.5f);

	//1
	glPushMatrix();
	glTranslatef(-9, -9, 0);
	glutSolidCylinder(0.1, 4, 10, 10);
	glPushMatrix();
	glTranslatef(0, 0, 4.5);
	if (glIsEnabled(GL_LIGHT1))
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
	else
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glutSolidSphere(0.5, 10, 10);
	glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glPopMatrix();
	glLightfv(GL_LIGHT1, GL_POSITION, light_pos);
	glPopMatrix();

	//2
	glPushMatrix();
	glTranslatef(-9, 9, 0);
	glutSolidCylinder(0.1, 4, 10, 10);
	glPushMatrix();
	glTranslatef(0, 0, 4.5);
	if (glIsEnabled(GL_LIGHT2))
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
	else
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glutSolidSphere(0.5, 10, 10);
	glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glPopMatrix();
	glLightfv(GL_LIGHT2, GL_POSITION, light_pos);
	glPopMatrix();

	//3
	glPushMatrix();
	glTranslatef(9, 9, 0);
	glutSolidCylinder(0.1, 4, 10, 10);
	glPushMatrix();
	glTranslatef(0, 0, 4.5);
	if (glIsEnabled(GL_LIGHT3))
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
	else
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glutSolidSphere(0.5, 10, 10);
	glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glPopMatrix();
	glLightfv(GL_LIGHT3, GL_POSITION, light_pos);
	glPopMatrix();

	//4
	glPushMatrix();
	glTranslatef(9, -9, 0);
	glutSolidCylinder(0.1, 4, 10, 10);
	glPushMatrix();
	glTranslatef(0, 0, 4.5);
	if (glIsEnabled(GL_LIGHT4))
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
	else
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glutSolidSphere(0.5, 10, 10);
	glPopMatrix();
	glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glLightfv(GL_LIGHT4, GL_POSITION, light_pos);
	glPopMatrix();
}

void drawCar()
{
	glPushMatrix();
	glTranslatef(dist_x, dist_y, 0);
	glRotatef(angle, 0, 0, 1);

	glColor3f(1, 1, 1);
	glBindTexture(GL_TEXTURE_2D, body_texture_id);
	glEnable(GL_TEXTURE_2D);
	glBegin(GL_QUADS);

	//Днище
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(-3, -1, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(-3, 2, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, 2, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(3, -1, 0.4);

	//Верзняя часть
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(-3, -1, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(-3, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(3, -1, 0.8);

	//Передний квадрат
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(-3, -1, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(-3, 2, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(-3, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(-3, -1, 0.8);

	//Задний квадрат
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(3, -1, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(3, 2, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(3, -1, 0.8);

	//Левый бок
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(-3, 2, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(3, 2, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(-3, 2, 0.8);

	//Правый бок
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(-3, -1, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(3, -1, 0.4);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, -1, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(-3, -1, 0.8);

	glEnd();
	glDisable(GL_TEXTURE_2D);

	glBindTexture(GL_TEXTURE_2D, cabin_texture_id);
	glEnable(GL_TEXTURE_2D);
	glBegin(GL_QUADS);

	//крыша кабины
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(3, -1, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(3, 2, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(1, 2, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(1, -1, 3);

	//Задняя часть кабины
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(1, -1, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(1, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(1, 2, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(1, -1, 3);

	//Передняя часть кабины
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(3, -1, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(3, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(3, 2, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, -1, 3);

	//Боковая часть кабины
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(1, 2, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(1, 2, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(3, 2, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, 2, 0.8);

	//Боковая часть кабины
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 0.0); glVertex3f(1, -1, 0.8);
	glNormal3f(0, 0, 1); glTexCoord2f(0.0, 1.0); glVertex3f(1, -1, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 0.0); glVertex3f(3, -1, 3);
	glNormal3f(0, 0, 1); glTexCoord2f(1.0, 1.0); glVertex3f(3, -1, 0.8);

	glEnd();
	glDisable(GL_TEXTURE_2D);

	//Колеса
	glPushMatrix();
	glTranslatef(1.5, -1, 0.4);
	glRotatef(90, 1, 0, 0);
	glutSolidTorus(0.1, 0.2, 10, 10); //переднее

	glPushMatrix();
	glTranslatef(-3.8, 0, 0);         //задние
	glutSolidTorus(0.1, 0.2, 10, 10); 
	glTranslatef(0.5, 0, 0);
	glutSolidTorus(0.1, 0.2, 10, 10);
	glPopMatrix();

	glTranslatef(0, 0, -3);         //с другой стороны	
	glutSolidTorus(0.1, 0.2, 10, 10);
	glTranslatef(-3.8, 0, 0);
	glutSolidTorus(0.1, 0.2, 10, 10);
	glTranslatef(0.5, 0, 0);
	glutSolidTorus(0.1, 0.2, 10, 10);
	glPopMatrix();

	//Фары
	glColor3f(1, 1, 1);
	glTranslatef(3, -0.3, 1);
	if (glIsEnabled(GL_LIGHT5))
		glMaterialfv(GL_FRONT, GL_EMISSION, light);
	else
		glMaterialfv(GL_FRONT, GL_EMISSION, no_light);

	glutSolidSphere(0.3, 5, 5);
	glTranslatef(0, 1.7, 0);
	glutSolidSphere(0.3, 5, 5);
	glMaterialfv(GL_FRONT, GL_EMISSION, no_light);
	glPopMatrix();
}

void update() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();

	double ang_vert_r = ang_vert / 180 * 3.1416;
	double ang_hor_r = ang_hor / 180 * 3.1416;
	cam_x = cam_dist * std::sin(ang_vert_r) * std::cos(ang_hor_r);
	cam_y = cam_dist * std::sin(ang_vert_r) * std::sin(ang_hor_r);
	cam_z = cam_dist * std::cos(ang_vert_r);

	float pos[] = { cam_x,cam_y,cam_z,1.0 };
	glLightfv(GL_LIGHT7, GL_POSITION, pos);
	gluLookAt(cam_x, cam_y, cam_z, 0., 0., 0., 0., 0., 1.);
	drawFloor();
	drawLamps();
	drawCar();

	glFlush();
	glutSwapBuffers();
}

void keyboard(unsigned char key, int x, int y) {
	switch (key) {
	case 'w':
		ang_vert += 5;
		break;
	case 's':
		ang_vert -= 5;
		break;
	case 'a':
		ang_hor -= 5;
		break;
	case 'd':
		ang_hor += 5;
		break;
	case 'q':
		cam_dist--;
		break;
	case 'z':
		cam_dist++;
		break;
	case '1':
		if (glIsEnabled(GL_LIGHT1))
			glDisable(GL_LIGHT1);
		else
			glEnable(GL_LIGHT1);
		break;
	case '2':
		if (glIsEnabled(GL_LIGHT2))
			glDisable(GL_LIGHT2);
		else
			glEnable(GL_LIGHT2);
		break;
	case '3':
		if (glIsEnabled(GL_LIGHT3))
			glDisable(GL_LIGHT3);
		else
			glEnable(GL_LIGHT3);
		break;
	case '4':
		if (glIsEnabled(GL_LIGHT4))
			glDisable(GL_LIGHT4);
		else
			glEnable(GL_LIGHT4);
		break;
	case '5':
		if (glIsEnabled(GL_LIGHT5))
		{
			glDisable(GL_LIGHT5);
			glDisable(GL_LIGHT6);
		}
		else
		{
			glEnable(GL_LIGHT5);
			glEnable(GL_LIGHT6);
		}
		break;
	default:
		break;
	case '6':
		if (glIsEnabled(GL_LIGHT7))
			glDisable(GL_LIGHT7);
		else
			glEnable(GL_LIGHT7);
		break;
	}
	glutPostRedisplay();
}

void SpecialKeys(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_UP:
		dist_x += std::cos(angle / 180 * 3.1416) * 0.3;
		dist_y += std::sin(angle / 180 * 3.1416) * 0.3;
		break;
	case GLUT_KEY_DOWN:
		dist_x -= std::cos(angle / 180 * 3.1416) * 0.3;
		dist_y -= std::sin(angle / 180 * 3.1416) * 0.3;
		break;
	case GLUT_KEY_LEFT:
		angle -= 5;
		break;
	case GLUT_KEY_RIGHT:
		angle += 5;
		break;
	}
	glutPostRedisplay();
}

int main(int argc, char* argv[]) {
	glutInit(&argc, argv);
	glutInitWindowPosition(100, 100);
	glutInitWindowSize(800, 600);
	glutCreateWindow("Texturing and lighting");

	init();

	glutReshapeFunc(reshape);
	glutDisplayFunc(update);
	glutKeyboardFunc(keyboard);
	glutSpecialFunc(SpecialKeys);

	glutMainLoop();

	return 0;
}
