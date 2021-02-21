(this["webpackJsonpschema-annotator-spa"]=this["webpackJsonpschema-annotator-spa"]||[]).push([[0],{66:function(e,t,a){},67:function(e,t,a){},75:function(e,t,a){"use strict";a.r(t);var n=a(2),c=a(0),i=a.n(c),s=a(21),r=a.n(s),l=(a(66),a.p+"static/media/app-logo.d685a859.svg"),o=(a(67),a(95)),d=a(90),j=a(26),p=a(9),h=a(20),x=a(89),b=a(96),u=a(92),m=a(93),f=a(91),O=a(35),g=a.n(O),y=a.p+"static/media/landing.bd12d204.svg",w=Object(x.a)((function(e){return{root:{marginTop:"7%",padding:"1% 2%",display:"flex",alignItems:"center",width:"100%",boxShadow:"0 1px 14px 2px #7b7b7b"},input:{marginLeft:e.spacing(1),flex:1,fontSize:"1.2vw"},iconButton:{padding:10,color:"#FC826A"},divider:{height:"1.2vw",margin:4}}}));var v=function(){var e=w(),t=Object(p.e)(),a=Object(c.useState)(""),s=Object(h.a)(a,2),r=s[0],l=s[1];return Object(n.jsxs)(i.a.Fragment,{children:[Object(n.jsx)(d.a,{item:!0,xs:5,children:Object(n.jsxs)("div",{className:"main-container",children:[Object(n.jsxs)(d.a,{item:!0,xs:12,children:[Object(n.jsx)("h1",{className:"main-title",children:"Structured Markup Generator"}),Object(n.jsx)("p",{className:"main-par",children:"Schema.org is the result of collaboration between Google, Bing, Yandex, and Yahoo! to improve the web by creating a structured data markup schema supported by major search engines. On-page markup helps search engines understand the information on web pages and provide richer search results!"}),Object(n.jsxs)("p",{className:"second-par",children:["Markup expert will help you generate structured-data markup by analyzing the content of your webpage; powered by",Object(n.jsx)("a",{href:"https://www.expert.ai/",target:"_blank",children:"expert.ai"})]})]}),Object(n.jsx)(d.a,{item:!0,xs:12,children:Object(n.jsxs)(f.a,{className:e.root,children:[Object(n.jsx)("form",{style:{width:"100%"},onSubmit:function(e){r&&t.push("/analyze?url=".concat(r)),e.preventDefault()},children:Object(n.jsx)(b.a,{style:{width:"100%"},className:e.input,placeholder:"Enter a Url to Analyze",inputProps:{"aria-label":"Url"},onChange:function(e){l(e.target.value)}})}),Object(n.jsx)(u.a,{className:e.divider,orientation:"vertical"}),Object(n.jsx)(m.a,{color:"primary",className:e.iconButton,"aria-label":"directions",onClick:function(){r&&t.push("/analyze?url=".concat(r))},children:Object(n.jsx)(g.a,{})})]})})]})}),Object(n.jsx)(d.a,{item:!0,xs:7,children:Object(n.jsxs)("div",{className:"landing-container",children:[Object(n.jsx)("img",{src:y}),Object(n.jsx)("a",{className:"freepik-refer",href:"https://www.freepik.com/vectors/design",children:"Designed by freepik"})]})})]})},k=a(98),C=a(94),S=a(99),T="",N=a(53),z=a.n(N),B=a(52),F=a.n(B),L=(a(74),Object(x.a)((function(e){return{root:{marginTop:"1%",marginBottom:"1%",marginRight:"1%",marginLeft:"1%",padding:"1% 2%",display:"flex",alignItems:"center",width:"97%",boxShadow:"0 1px 14px 2px #7b7b7b"},input:{marginLeft:e.spacing(1),flex:1,fontSize:"1.2vw"},iconButton:{padding:10,color:"#FC826A"},divider:{height:"1.2vw",margin:4}}}))),D={};var G=function(){var e,t,a,s,r=L(),l=Object(p.e)(),j=new URLSearchParams(Object(p.f)().search).get("url"),x=Object(c.useState)(j),O=Object(h.a)(x,2),y=O[0],w=O[1],v=Object(c.useState)({data:{mappings:[]},hasError:!1}),N=Object(h.a)(v,2),B=N[0],G=N[1],E=Object(c.useState)(!1),P=Object(h.a)(E,2),I=P[0],U=P[1],A=Object(c.useState)(!1),M=Object(h.a)(A,2),_=M[0],J=M[1];return I||fetch("".concat(T,"/markup/url-markup"),{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify({url:j})}).then((function(e){e.json().then((function(e){e.hasError?window.alert(e.message):(D={},G(e),J(!0))}))})),Object(c.useEffect)((function(){U(!0)}),[]),Object(n.jsx)(i.a.Fragment,{children:Object(n.jsxs)(d.a,{container:!0,style:{borderTop:"1px solid #ccc"},children:[Object(n.jsxs)(d.a,{item:!0,xs:9,children:[_?null:Object(n.jsx)(k.a,{}),Object(n.jsxs)(f.a,{className:r.root,children:[Object(n.jsx)("form",{style:{width:"100%"},onSubmit:function(e){y&&l.push("/analyze?url=".concat(y)),e.preventDefault()},children:Object(n.jsx)(b.a,{style:{width:"100%"},defaultValue:j,className:r.input,placeholder:"Enter a Url to Analyze",inputProps:{"aria-label":"Url"},onChange:function(e){w(e.target.value)}})}),Object(n.jsx)(u.a,{className:r.divider,orientation:"vertical"}),Object(n.jsx)(m.a,{color:"primary",className:r.iconButton,"aria-label":"directions",onClick:function(){y&&(window.location.href="/analyze?url=".concat(y))},children:Object(n.jsx)(g.a,{})})]}),Object(n.jsx)("iframe",{id:"web-frame",src:"".concat(T,"/markup/webpage?url=").concat(j),height:"100%",width:"100%"})]}),Object(n.jsxs)(d.a,{item:!0,xs:3,style:{padding:"10px",borderLeft:"1px solid #ccc"},children:[Object(n.jsx)("div",{style:{color:"#FC826A",fontSize:"2.2vw"},children:"Schemas:"}),_?null:Object(n.jsx)(C.a,{}),Object(n.jsx)("div",{className:"schemas-container",children:null===B||void 0===B||null===(e=B.data)||void 0===e||null===(t=e.mappings)||void 0===t?void 0:t.map((function(e){return Object(n.jsx)(f.a,{style:{margin:"15px 0",padding:"10px"},children:Object(n.jsxs)(o.a,{display:"flex",flexDirection:"column",flexGrow:"1",children:[Object(n.jsxs)(o.a,{display:"flex",justifyContent:"space-between",flexGrow:"1",children:[Object(n.jsx)(o.a,{display:"flex",justifyContent:"flex-start",children:Object(n.jsx)(o.a,{className:"schema-link",children:Object(n.jsxs)("a",{href:"https://schema.org/".concat(e.schemaOrgType.schemaType),target:"_blank",children:[e.schemaOrgType.schemaType," ",Object(n.jsx)("span",{style:{color:"#aaa",fontSize:"0.5vw"},children:"(schema.org)"})]})})}),Object(n.jsx)(o.a,{display:"flex",justifyContent:"flex-end",flexGrow:"1",children:Object(n.jsx)(o.a,{flexDirection:"column",justifyContent:"flex-end",children:Object(n.jsx)(o.a,{display:"flex",children:Object(n.jsx)(S.a,{size:"small",icon:Object(n.jsx)(z.a,{}),label:"Find in page",clickable:!0,color:"primary",onClick:function(){var t,a,n=D[e.schemaOrgType.schemaType];void 0==n?(n=0,D[e.schemaOrgType.schemaType]=n):(n=(n+1)%e.positions.length,D[e.schemaOrgType.schemaType]=n);var c=e.positions[n],i=null===(t=B.data)||void 0===t||null===(a=t.document)||void 0===a?void 0:a.text.substring(c.start,c.end);document.getElementById("web-frame").contentWindow.window.find(i,!1,!1,!0,!0,!0,!1)}})})})})]}),Object(n.jsxs)(o.a,{display:"flex",flexGrow:"1",style:{marginTop:"15px"},flexDirection:"column",children:[Object(n.jsx)(o.a,{display:"flex",style:{color:"#CCC",fontSize:"0.5vw",marginBottom:"5px"},children:"mappings with IPTC:"}),Object(n.jsx)(o.a,{display:"flex",children:e.iptcCategories.map((function(e){return Object(n.jsx)(o.a,{children:Object(n.jsx)(S.a,{style:{marginLeft:"5px"},label:e.iptcLabel})})}))})]}),Object(n.jsxs)(o.a,{display:"flex",flexGrow:"1",style:{marginTop:"15px"},flexDirection:"column",children:[Object(n.jsx)(o.a,{display:"flex",style:{color:"#CCC",fontSize:"0.5vw",marginBottom:"5px"},children:"mapped words:"}),Object(n.jsx)(o.a,{display:"flex",children:e.positions.map((function(e){var t,a;return Object(n.jsx)(o.a,{children:Object(n.jsx)(S.a,{style:{marginLeft:"5px"},color:"secondary",label:null===(t=B.data)||void 0===t||null===(a=t.document)||void 0===a?void 0:a.text.substring(e.start,e.end),variant:"outlined"})})}))})]})]})})}))}),Object(n.jsxs)("div",{className:"jsonld-container",children:[Object(n.jsx)("a",{className:"jsonld-link",target:"blank",href:"https://developers.google.com/search/docs/guides/intro-structured-data",children:"Understand how structured data works"}),Object(n.jsx)(F.a,{style:{marginTop:"15px"},enableClipboard:!0,displayDataTypes:!1,src:{"@context":"http://schema.org","@graph":null===B||void 0===B||null===(a=B.data)||void 0===a||null===(s=a.mappings)||void 0===s?void 0:s.map((function(e){return{"@type":e.schemaOrgType.schemaType}}))}})]})]})]})})};var E=function(){return Object(n.jsx)(i.a.Fragment,{children:Object(n.jsx)(j.a,{children:Object(n.jsxs)(d.a,{container:!0,children:[Object(n.jsx)(d.a,{item:!0,xs:12,style:{height:105,overflow:"hidden"},children:Object(n.jsxs)(o.a,{display:"flex",justifyContent:"space-between",children:[Object(n.jsx)(o.a,{display:"flex",justifyContent:"flex-start",children:Object(n.jsx)(j.b,{to:"/",children:Object(n.jsx)("img",{src:l,className:"app-logo"})})}),Object(n.jsxs)(o.a,{display:"flex",justifyContent:"flex-end",flexGrow:"1",className:"menu-container",children:[Object(n.jsx)(o.a,{className:"menu-link",children:Object(n.jsx)("a",{href:"https://github.com/naceio/StructuredMarkupHelper",target:"_blank",children:"github"})}),Object(n.jsx)(o.a,{className:"menu-link",children:Object(n.jsx)("a",{href:"https://www.expert.ai/",target:"_blank",children:"expert.ai"})})]})]})}),Object(n.jsx)(p.a,{path:"/analyze",exact:!0,children:Object(n.jsx)(G,{})}),Object(n.jsx)(p.a,{path:"/",exact:!0,children:Object(n.jsx)(v,{})})]})})})},P=function(e){e&&e instanceof Function&&a.e(3).then(a.bind(null,101)).then((function(t){var a=t.getCLS,n=t.getFID,c=t.getFCP,i=t.getLCP,s=t.getTTFB;a(e),n(e),c(e),i(e),s(e)}))};r.a.render(Object(n.jsx)(i.a.StrictMode,{children:Object(n.jsx)(E,{})}),document.getElementById("root")),P()}},[[75,1,2]]]);
//# sourceMappingURL=main.1116436e.chunk.js.map