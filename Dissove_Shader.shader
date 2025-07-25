Shader "Custom/Dissolve_Shader"
{
    Properties
    {
        _MainTex ("Albedo", 2D) = "white" {}
        _DissolveTex ("Dissolve Noise", 2D) = "gray" {}
        _DissolveAmount ("Dissolve Amount", Range(0,1)) = 0.0
        _Color ("Color", Color) = (1,1,1,1)
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
    }

    SubShader
    {
        Tags { "RenderType"="TransparentCutout" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:clip

        sampler2D _MainTex;
        sampler2D _DissolveTex;
        float _DissolveAmount;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_DissolveTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 col = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            float dissolve = tex2D(_DissolveTex, IN.uv_DissolveTex).r;

            clip(dissolve - _DissolveAmount); // Alpha clipping
            o.Albedo = col.rgb;
            o.Alpha = col.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
