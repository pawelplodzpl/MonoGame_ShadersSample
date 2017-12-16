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
float3 LightColor = 1.0;
float3 AmbientColor = 0.35;

Texture2D SpriteTexture;
Texture2D NormalTexture;

SamplerState TextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

SamplerState NormalSampler = sampler_state
{
    Texture = <NormalTexture>;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
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


technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};
