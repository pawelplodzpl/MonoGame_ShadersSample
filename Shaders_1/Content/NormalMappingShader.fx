#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

// Effect applies normalmapped lighting to a 2D sprite.

float3 LightDirection;
float3 LightColor = { 0.1, 0.99, 0.1 };
//float3 AmbientColor = 0.55;
float3 AmbientColor = { 0.5, 0.1, 0.99 };

Texture2D SpriteTexture;
Texture2D NormalTexture;

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};

// Version 1
SamplerState TextureSampler = sampler_state
{
    Texture = <SpriteTexture>;
};

SamplerState NormalSampler = sampler_state
{
    Texture = <NormalTexture>;
};


float4 MainPS(float4 pos : SV_POSITION, float4 color : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{

    //get pixel info from the texture
    float4 tex = SpriteTexture.Sample(TextureSampler, texCoord);

	//Look up the normalmap value
    float4 normal = 2 * NormalTexture.Sample(NormalSampler, texCoord) - 1;


	// Compute lighting.
    float lightAmount = saturate(dot(normal.xyz, LightDirection));
    color.rgb *= AmbientColor + (lightAmount * LightColor);

    return color * tex;
}
//END Version 1


////Version 2
//sampler2D TextureSampler = sampler_state
//{
//    Texture = <SpriteTexture>;
//};

//sampler2D NormalSampler = sampler_state
//{
//    Texture = <NormalTexture>;
//};

//float4 MainPS(VertexShaderOutput input) : SV_TARGET0
//{
//    //get pixel info from the texture
//    //float4 tex = SpriteTexture.Sample(TextureSampler, texCoord);
//    float4 tex = tex2D(TextureSampler, input.TextureCoordinates);
//	//Look up the normalmap value
//    float4 normal = 2 * tex2D(NormalSampler, input.TextureCoordinates) - 1;
//    //float4 normal = 2 * NormalTexture.Sample(NormalSampler, texCoord) - 1;


//	// Compute lighting.
//    float lightAmount = saturate(dot(normal.xyz, LightDirection));
//    input.Color.rgb *= AmbientColor + (lightAmount * LightColor);

//    return input.Color * tex;
//}
//// END Version 2



technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};
