#version 330

in vec2 f_texcoord;
out vec4 outputColor;

uniform sampler2D maintexture;

void
main()
{
 vec2 flipped_texcoord = vec2(f_texcoord.x, 1.0 - f_texcoord.y);
    outputColor = texture(maintexture, flipped_texcoord)*vec4(0.6,0.6,1.0,1.0);
}