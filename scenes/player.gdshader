shader_type canvas_item;

void fragment()
{
 vec4 a=
 texture(TEXTURE,UV);

 vec4 b=
 texture(TEXTURE,
 UV+vec2(-.03,0));

 b.rgb=
 vec3(0,1,1);

 b.a*=0.4;

 COLOR=a+b;
}