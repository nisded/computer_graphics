out vec4 color;

uniform bool use_texture;
uniform	sampler2D cur_texture;

// параметры, полученные из вершинного шейдера
in Vertex{
	vec2 texcoord;
	vec4 vert_color;
	vec3 our_color;
} Vert;

void main()
{
	if(use_texture)
		color = Vert.vert_color * texture(cur_texture, Vert.texcoord);
	else
		color = Vert.vert_color * vec4(Vert.our_color,1);
}