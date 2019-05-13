// gklab09.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "pch.h"
#include <stdlib.h>
#include "glut.h"

//Nastêpnie nale¿y wstawiæ funkcje sk³adowe programu :
enum
{
	punkty, 
	lines, line_strip, line_loop,
	triangles, triangles_strip, 
	triangle_fan, quads, 
	quad_strip, polygon, EXIT, TROJKAT, KWADRAT
};
int object;
void Display()
{
	glClearColor(1.0, 1.0, 1.0, 1.0);
	glClear(GL_COLOR_BUFFER_BIT);
	glMatrixMode(GL_MODELVIEW);
	glColor3f(1.0, 0.0, 0.0);
	switch (object)
	{
		// trojkat
	case TROJKAT: {
		glBegin(GL_TRIANGLES);
		// kolejne wierzcho³ki wielok¹ta
		glVertex3f(0.0, 0.0, 0.0);
		glVertex3f(0.0, 1.0, 1.0);
		glVertex3f(1.0, 0.0, 0.0);
		glEnd();
		break; }
				  // kwadrat
	case KWADRAT: {
		glBegin(GL_POLYGON);
		glVertex3f(0.0, 0.0, 0.0);
		glVertex3f(0.0, 1.0, 0.0);
		glVertex3f(1.0, 1.0, 0.0);
		glVertex3f(1.0, 0.0, 0.0);
		glEnd();
		break; }
	case punkty: {
		glPointSize(5);
		glBegin(GL_POINTS);
		glVertex2f(0.0, 0.0);
		glVertex2f(0.5, 0.5);
		glVertex2f(-0.5, 0.0);
		glEnd();
		break;
	}
	case lines: {
		glBegin(GL_LINES);
		glVertex2f(-1.0, -1.0);
		glVertex2f(1.0, 1.0);
		glEnd();
		break;
	}
	case line_strip: {
		glBegin(GL_LINE_STRIP);
		glVertex2f(0.0, -0.9);
		glVertex2f(-0.5, 0.5);
		glVertex2f(0.75, 0.9);
		glEnd();
		break;
	}
	case line_loop: {
		glBegin(GL_LINE_LOOP);
		glVertex2f(0.0, -0.9);
		glVertex2f(-0.5, 0.5);
		glVertex2f(0.75, 0.9);
		glEnd();
		break;
	}
	case triangles: {
		glBegin(GL_TRIANGLES);
		glVertex2f(0.0, 0.0);
		glVertex2f(1.0, 1.0);
		glVertex2f(-0.5, 0.7);
		glVertex2f(0.8, -0.1);
		glVertex2f(-1.0, 1.0);
		glVertex2f(0.5, 0.3);
		glEnd();
		break;
	}
	case triangles_strip: {
		glBegin(GL_TRIANGLE_STRIP);
		glVertex2f(0.0, 0.0);
		glVertex2f(1.0, 1.0);
		glVertex2f(-0.5, 0.7);
		glVertex2f(0.8, -0.1);
		glVertex2f(-1.0, 1.0);
		glVertex2f(0.5, 0.3);
		glEnd();
		break;
	}
	case triangle_fan: {
		glBegin(GL_TRIANGLE_FAN);
		glVertex2f(0.0, 0.0);
		glVertex2f(1.0, 1.0);
		glVertex2f(-0.5, 0.7);
		glVertex2f(0.8, -0.1);
		glVertex2f(-1.0, 1.0);
		glVertex2f(0.5, 0.3);
		glEnd();
		break;
	}
	case quads: {
		glBegin(GL_QUADS);
		glVertex2f(-0.25f, 0.25f); // vertex 1
		glVertex2f(-0.5f, -0.25f); // vertex 2
		glVertex2f(0.5f, -0.25f); // vertex 3
		glVertex2f(0.25f, 0.25f);
		glEnd();
		break;
	}
	case quad_strip: {
		glBegin(GL_QUAD_STRIP);
		glVertex2f(0.25, 0.25); // vertex 1
		glVertex2f(0.25, -0.25); // vertex 2
		glVertex2f(0.5, -0.25); // vertex 3
		glVertex2f(0.5, 0.25);
		glVertex2f(0.75, -0.25);
		glVertex2f(1.0, -0.25);
		glVertex2f(1.0, 0.25);
		glEnd();
		break;
	}
	case polygon: {
		glBegin(GL_POLYGON);
		glVertex2f(-1.0, 1.0);
		glVertex2f(-0.75, 0.0);
		glVertex2f(0.0, 0.0);
		glVertex2f(0.8, -0.3);
		glVertex2f(0.7, 0.6);
		glVertex2f(1.0, 1.0);
		glEnd();
		break;
	}
	case EXIT: {
		exit(0);
		break;
	}
	}
	glFlush();
	glutSwapBuffers();
}
void Reshape(int width, int height)
{
	Display();
}
void Menu(int value)
{
	object = value;
	Display();
}
int main(int argc, char * argv[])
{
	glutInit(&argc, argv);
	glHint(GL_POINT_SMOOTH, GL_NICEST);
	glEnable(GL_POINT_SMOOTH);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(400, 400);
	glutCreateWindow("Pierwszy program");
	glutDisplayFunc(Display);
	glutReshapeFunc(Reshape);
	glutCreateMenu(Menu);
	glutAddMenuEntry("punkt", punkty);
	glutAddMenuEntry("lines", lines);
	glutAddMenuEntry("line_strip", line_strip);
	glutAddMenuEntry("line_loop", line_loop);
	glutAddMenuEntry("triangles", triangles);
	glutAddMenuEntry("triangles_strip", triangles_strip);
	glutAddMenuEntry("triangle_fan", triangle_fan);
	glutAddMenuEntry("quads", quads);
	glutAddMenuEntry("quad_strip", quad_strip);
	glutAddMenuEntry("polygon", polygon);
	//glutAddMenuEntry("Trojkat", TROJKAT);
	//glutAddMenuEntry("Kwadrat", KWADRAT);
	glutAddMenuEntry("wyjscie", EXIT);
	glutAttachMenu(GLUT_RIGHT_BUTTON);
	glutMainLoop();
	return 0;
}