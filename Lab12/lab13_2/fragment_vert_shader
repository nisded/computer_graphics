uniform vec4 v_color1;
uniform vec4 v_color2;
uniform int lines;
void main() {
if (mod(gl_FragCoord.x, 2*lines) <lines)
gl_FragColor = v_color1;
else
gl_FragColor = v_color2;
}