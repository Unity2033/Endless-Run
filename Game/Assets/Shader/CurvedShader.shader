Shader"Curved/CurvedShader"
{
 Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Curvature("Curvature", float) = 0.001
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert addshadow

        uniform sampler2D _MainTex;
        uniform float _Curvature;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v)
        {
            float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);
            worldSpace.xyz -= _WorldSpaceCameraPos.xyz;

            float offset = (worldSpace.z * worldSpace.z) * -_Curvature;
            float3 offsetWorld = float3(offset, 0.0f, 0.0f); // Y축 편차 제거

            v.vertex += mul(unity_WorldToObject, float4(offsetWorld, 0.0f));
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            half4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        ENDCG        
    }
    FallBack "Mobile/Diffuse"
}
