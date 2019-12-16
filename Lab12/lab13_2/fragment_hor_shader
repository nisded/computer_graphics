uniform vec4 h_color1;
uniform vec4 h_color2;
uniform int lines;
void main() {
if (mod(gl_FragCoord.y, 2*lines) <lines)
gl_FragColor = h_color1;
else
gl_FragColor = h_color2;
}