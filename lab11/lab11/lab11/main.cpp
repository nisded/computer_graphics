#include "soil.h"
#include "freeglut.h"

#include <iostream>

static int w = 0, h = 0;

GLuint floor_texture_id;

GLfloat cam_dist = 20;
GLfloat ang_hor = 0, ang_vert = -60;
double cam_x = 0;
double cam_y = 0;
double cam_z = 0;

const double step = 1;

void loadTextures() {
	floor_texture_id = SOIL_load_OGL_texture("..\\..\\textures\\road-stone-texture.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID,
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

void update() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();

	double ang_vert_r = ang_vert / 180 * 3.1416;
	double ang_hor_r = ang_hor / 180 * 3.1416;
	cam_x = cam_dist * std::sin(ang_vert_r) * std::cos(ang_hor_r);
	cam_y = cam_dist * std::sin(ang_vert_r) * std::sin(ang_hor_r);
	cam_z = cam_dist * std::cos(ang_vert_r);

	gluLookAt(cam_x, cam_y, cam_z, 0., 0., 0., 0., 0., 1.);
	drawFloor();

	glFlush();
	glutSwapBuffers();
}

void updateCamera() {
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(60.f, (float)w / h, 1.0f, 1000.f);
	glMatrixMode(GL_MODELVIEW);
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
	}
	glutPostRedisplay();
}

void reshape(int width, int height) {
	w = width;
	h = height;

	glViewport(0, 0, w, h);
	updateCamera();
}

int main(int argc, char* argv[]) {
	glutInit(&argc, argv);
	glutInitWindowPosition(100, 100);
	glutInitWindowSize(800, 800);
	glutCreateWindow("texture and lighting");

	init();

	glutReshapeFunc(reshape);
	glutDisplayFunc(update);
	glutKeyboardFunc(keyboard);

	glutMainLoop();

	return 0;
}
