Shader "Unlit/ParticleIndirectRendering"
{
    Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            half4 _BaseColor;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
            };

            struct v2_f
            {
                float4 vertex : SV_POSITION;
            };

            StructuredBuffer<float4x4> positionBuffer;

            v2_f vert(const appdata_t i, const uint instance_id: SV_InstanceID)
            {
                v2_f o;

                const float4 pos = mul(positionBuffer[instance_id], i.vertex);
                o.vertex = UnityObjectToClipPos(pos);

                return o;
            }

            fixed4 frag(v2_f i) : SV_Target
            {
                return _BaseColor;
            }
            ENDCG
        }
    }
}