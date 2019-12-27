layout(location = 0) in vec3 position;
layout(location = 1) in vec3 norm;
layout(location = 2) in vec2 texcoord;

uniform vec3 col;

uniform struct Transform {
	mat4 model;
	mat4 viewProjection;
	mat3 normal;
	vec3 viewPosition;
} transform;

uniform struct PointLight {
	vec4 position;
	vec4 ambient;
	vec4 diffuse;
	vec4 specular;
	vec3 attenuation;
} light;

uniform struct Material {
	vec4 ambient;
	vec4 diffuse;
	vec4 specular;
	vec4 emission;
	float shiness;
} material;

out Vertex{
	vec2 texcoord;
	vec4 vert_color;
	vec3 our_color;
} Vert;

void main()
{	 
	vec4 vertex = transform.model * vec4(position, 1.0f);
	vec4 lightDir4 = light.position - vertex;
    gl_Position = transform.viewProjection * vertex;
	vec3 normal = normalize(transform.normal * norm);
	vec3 lightDir = normalize(vec3(lightDir4));	
	vec3 viewDir = normalize(transform.viewPosition - vec3(vertex));
	
	float vert_distance = length(lightDir4);
	
	float attenuation = 1.0 / (light.attenuation[0] + light.attenuation[1] * Vert.distance + light.attenuation[2] * Vert.distance*Vert.distance);
	
	vec4 colorW = material.emission;
	colorW += material.ambient * light.ambient * attenuation;
	float Ndot = max(dot(normal, lightDir), 0.0);
	colorW += material.diffuse * light.diffuse * Ndot * attenuation;
	
	// добавление отражённого света
	float RdotVpow = max(pow(dot(reflect(-lightDir, normal), viewDir), material.shiness), 0.0);
	colorW += material.specular * light.specular * RdotVpow * attenuation;
	
	Vert.texcoord = texcoord;
	Vert.vert_color = colorW;
	Vert.our_color = col;
}
