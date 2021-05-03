(function(e){function n(n){for(var t,a,u=n[0],c=n[1],s=n[2],l=0,f=[];l<u.length;l++)a=u[l],Object.prototype.hasOwnProperty.call(o,a)&&o[a]&&f.push(o[a][0]),o[a]=0;for(t in c)Object.prototype.hasOwnProperty.call(c,t)&&(e[t]=c[t]);p&&p(n);while(f.length)f.shift()();return i.push.apply(i,s||[]),r()}function r(){for(var e,n=0;n<i.length;n++){for(var r=i[n],t=!0,a=1;a<r.length;a++){var u=r[a];0!==o[u]&&(t=!1)}t&&(i.splice(n--,1),e=c(c.s=r[0]))}return e}var t={},a={1:0},o={1:0},i=[];function u(e){return c.p+"js/"+({}[e]||e)+"."+{2:"7e637ca3",3:"7d527c03",4:"3a208c77",5:"a3847e1b"}[e]+".js"}function c(n){if(t[n])return t[n].exports;var r=t[n]={i:n,l:!1,exports:{}};return e[n].call(r.exports,r,r.exports,c),r.l=!0,r.exports}c.e=function(e){var n=[],r={2:1,3:1};a[e]?n.push(a[e]):0!==a[e]&&r[e]&&n.push(a[e]=new Promise((function(n,r){for(var t="css/"+({}[e]||e)+"."+{2:"151fb0bd",3:"030ad385",4:"31d6cfe0",5:"31d6cfe0"}[e]+".css",o=c.p+t,i=document.getElementsByTagName("link"),u=0;u<i.length;u++){var s=i[u],l=s.getAttribute("data-href")||s.getAttribute("href");if("stylesheet"===s.rel&&(l===t||l===o))return n()}var f=document.getElementsByTagName("style");for(u=0;u<f.length;u++){s=f[u],l=s.getAttribute("data-href");if(l===t||l===o)return n()}var p=document.createElement("link");p.rel="stylesheet",p.type="text/css",p.onload=n,p.onerror=function(n){var t=n&&n.target&&n.target.src||o,i=new Error("Loading CSS chunk "+e+" failed.\n("+t+")");i.code="CSS_CHUNK_LOAD_FAILED",i.request=t,delete a[e],p.parentNode.removeChild(p),r(i)},p.href=o;var d=document.getElementsByTagName("head")[0];d.appendChild(p)})).then((function(){a[e]=0})));var t=o[e];if(0!==t)if(t)n.push(t[2]);else{var i=new Promise((function(n,r){t=o[e]=[n,r]}));n.push(t[2]=i);var s,l=document.createElement("script");l.charset="utf-8",l.timeout=120,c.nc&&l.setAttribute("nonce",c.nc),l.src=u(e);var f=new Error;s=function(n){l.onerror=l.onload=null,clearTimeout(p);var r=o[e];if(0!==r){if(r){var t=n&&("load"===n.type?"missing":n.type),a=n&&n.target&&n.target.src;f.message="Loading chunk "+e+" failed.\n("+t+": "+a+")",f.name="ChunkLoadError",f.type=t,f.request=a,r[1](f)}o[e]=void 0}};var p=setTimeout((function(){s({type:"timeout",target:l})}),12e4);l.onerror=l.onload=s,document.head.appendChild(l)}return Promise.all(n)},c.m=e,c.c=t,c.d=function(e,n,r){c.o(e,n)||Object.defineProperty(e,n,{enumerable:!0,get:r})},c.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},c.t=function(e,n){if(1&n&&(e=c(e)),8&n)return e;if(4&n&&"object"===typeof e&&e&&e.__esModule)return e;var r=Object.create(null);if(c.r(r),Object.defineProperty(r,"default",{enumerable:!0,value:e}),2&n&&"string"!=typeof e)for(var t in e)c.d(r,t,function(n){return e[n]}.bind(null,t));return r},c.n=function(e){var n=e&&e.__esModule?function(){return e["default"]}:function(){return e};return c.d(n,"a",n),n},c.o=function(e,n){return Object.prototype.hasOwnProperty.call(e,n)},c.p="/",c.oe=function(e){throw console.error(e),e};var s=window["webpackJsonp"]=window["webpackJsonp"]||[],l=s.push.bind(s);s.push=n,s=s.slice();for(var f=0;f<s.length;f++)n(s[f]);var p=l;i.push([0,0]),r()})({0:function(e,n,r){e.exports=r("2f39")},"0047":function(e,n,r){},"1a52":function(e,n){},"2f39":function(e,n,r){"use strict";r.r(n);var t={};r.r(t),r.d(t,"isInitialized",(function(){return E})),r.d(t,"loading",(function(){return L})),r.d(t,"messages",(function(){return A})),r.d(t,"users",(function(){return z}));var a={};r.r(a),r.d(a,"loading",(function(){return B})),r.d(a,"joinedRoom",(function(){return V})),r.d(a,"brJoinedRoom",(function(){return N})),r.d(a,"leftRoom",(function(){return q})),r.d(a,"brLeftRoom",(function(){return U})),r.d(a,"messageCreated",(function(){return $})),r.d(a,"brMessageCreated",(function(){return F}));var o={};r.r(o),r.d(o,"create",(function(){return Y})),r.d(o,"patch",(function(){return ee}));var i={};r.r(i),r.d(i,"user",(function(){return ae})),r.d(i,"loading",(function(){return oe}));var u={};r.r(u),r.d(u,"loading",(function(){return ie})),r.d(u,"userCreated",(function(){return ue}));var c={};r.r(c),r.d(c,"create",(function(){return ce}));var s={};r.r(s),r.d(s,"create",(function(){return he}));var l={};r.r(l),r.d(l,"isChimeInitialized",(function(){return ye})),r.d(l,"meetingResponse",(function(){return Oe})),r.d(l,"attendeeResponse",(function(){return je})),r.d(l,"attendeeId",(function(){return xe})),r.d(l,"loading",(function(){return ke}));var f={};r.r(f),r.d(f,"loading",(function(){return Me})),r.d(f,"chimeMeetingCreated",(function(){return Se})),r.d(f,"joinedChimeMeeting",(function(){return Ie})),r.d(f,"leaveChimeMeeting",(function(){return Ee}));var p={};r.r(p),r.d(p,"createChimeMeeting",(function(){return Le})),r.d(p,"joinChimeMeeting",(function(){return ze}));var d=r("a34a"),g=r.n(d),m=(r("a481"),r("96cf"),r("c973")),h=r.n(m),v=(r("5c7d"),r("573e"),r("7d6e"),r("e54f"),r("985d"),r("0047"),r("2b0e")),b=r("1f91"),w=r("42d2"),y=r("b05d"),O=r("2a19");v["a"].use(y["a"],{config:{},lang:b["a"],iconSet:w["a"],plugins:{Notify:O["a"]}});var j=function(){var e=this,n=e.$createElement,r=e._self._c||n;return r("div",{attrs:{id:"q-app"}},[r("router-view")],1)},x=[],k={name:"App"},C=k,P=r("2877"),R=Object(P["a"])(C,j,x,!1,null,null,null),M=R.exports,S=r("2f62"),I=function(){return{roomIdentifier:null,isInitialized:!1,users:[],messages:[],loading:!1}};function E(e){return e.isInitialized}function L(e){return e.loading}function A(e){return e.messages}function z(e){return e.users}r("8e6e"),r("8a81"),r("ac6a"),r("cadf"),r("06db"),r("456d");var _=r("9523"),D=r.n(_);r("f751");function J(e,n){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var t=Object.getOwnPropertySymbols(e);n&&(t=t.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),r.push.apply(r,t)}return r}function T(e){for(var n=1;n<arguments.length;n++){var r=null!=arguments[n]?arguments[n]:{};n%2?J(Object(r),!0).forEach((function(n){D()(e,n,r[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):J(Object(r)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(r,n))}))}return e}function B(e,n){e.loading=n}function V(e,n){e.loading=!1,n.error?O["a"].create({message:"Oops, an error occured, please try again",color:"warning"}):Object.assign(e,T(T({},n),{},{isInitialized:!0}))}function N(e,n){e.loading=!1,n.error?O["a"].create({message:"Oops, an error occured, please try again",color:"warning"}):Object.assign(e,{users:n.users})}function q(e,n){if(e.loading=!1,!n||n.error)return O["a"].create({message:"Oops, an error occured, please try again",color:"warning"});Object.assign(e,{roomIdentifier:null,users:[],messages:[],isInitialized:!1})}function U(e,n){if(e.loading=!1,!n||n.error)return O["a"].create({message:"Oops, an error occured, please try again",color:"warning"});Object.assign(e,{users:n.users})}function $(e,n){if(e.loading=!1,!n||n.error)return O["a"].create({message:"Oops, an error occured, please try again",color:"warning"});e.messages.push(n.message)}function F(e,n){if(e.loading=!1,!n||n.error)return O["a"].create({message:"Oops, an error occured, please try again",color:"warning"});e.messages.push(n.message)}var H=r("e87a"),K={UserCreated:"user/userCreated",JoinedRoom:"room/joinedRoom",BrJoinedRoom:"room/brJoinedRoom",LeftRoom:"room/leftRoom",BrLeftRoom:"room/brLeftRoom",MessageCreated:"room/messageCreated",BrMessageCreated:"room/brMessageCreated",ChimeMeetingCreated:"chime/chimeMeetingCreated",JoinedChimeMeeting:"chime/joinedChimeMeeting"},Q=(new H["a"]).withUrl("/chathub").configureLogging(H["b"].Information).build();function G(){return W.apply(this,arguments)}function W(){return W=h()(g.a.mark((function e(){return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.prev=0,e.next=3,Q.start();case 3:console.log("SignalR Connected."),e.next=10;break;case 6:e.prev=6,e.t0=e["catch"](0),console.log(e.t0),setTimeout(G,5e3);case 10:case"end":return e.stop()}}),e,null,[[0,6]])}))),W.apply(this,arguments)}var X=function(e){e.app,e.router;var n=e.store,r=e.Vue;G(),Q.onclose(G);var t=function(e){Q.on(e,(function(r){n.commit(K[e],r)}))};for(var a in K)t(a);r.prototype.$connection=Q};function Y(e,n){return Z.apply(this,arguments)}function Z(){return Z=h()(g.a.mark((function e(n,r){var t;return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return t=n.commit,e.prev=1,e.next=4,Q.invoke("JoinRoom",r);case 4:e.next=10;break;case 6:return e.prev=6,e.t0=e["catch"](1),t("loading",!1),e.abrupt("return",!1);case 10:case"end":return e.stop()}}),e,null,[[1,6]])}))),Z.apply(this,arguments)}function ee(e,n){return ne.apply(this,arguments)}function ne(){return ne=h()(g.a.mark((function e(n,r){var t;return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return t=n.commit,e.prev=1,e.next=4,Q.invoke("LeaveRoom",r);case 4:e.next=10;break;case 6:return e.prev=6,e.t0=e["catch"](1),t("loading",!1),e.abrupt("return",!1);case 10:case"end":return e.stop()}}),e,null,[[1,6]])}))),ne.apply(this,arguments)}var re={namespaced:!0,getters:t,mutations:a,actions:o,state:I},te=function(){return{user:null,loading:!1}};function ae(e){return e.user}function oe(e){return e.loading}r("7f7f");function ie(e,n){e.loading=n}function ue(e,n){if(e.loading=!1,!n||n.error)return O["a"].create({message:"Oops, an error occured, please try again",color:"warning"});Object.assign(e,{user:{id:n.id,name:n.name}})}function ce(e,n){return se.apply(this,arguments)}function se(){return se=h()(g.a.mark((function e(n,r){var t;return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return t=n.commit,e.prev=1,e.next=4,Q.invoke("CreateUser",r);case 4:e.next=10;break;case 6:return e.prev=6,e.t0=e["catch"](1),t("loading",!1),e.abrupt("return",!1);case 10:case"end":return e.stop()}}),e,null,[[1,6]])}))),se.apply(this,arguments)}var le={namespaced:!0,getters:i,mutations:u,actions:c,state:te},fe=function(){return{}},pe=r("643e"),de=r("1a52"),ge=r("643a"),me=r.n(ge);function he(e,n){return ve.apply(this,arguments)}function ve(){return ve=h()(g.a.mark((function e(n,r){return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return me()(n),e.prev=1,e.next=4,Q.invoke("CreateMessage",r);case 4:e.next=9;break;case 6:return e.prev=6,e.t0=e["catch"](1),e.abrupt("return",!1);case 9:case"end":return e.stop()}}),e,null,[[1,6]])}))),ve.apply(this,arguments)}var be={namespaced:!0,getters:pe,mutations:de,actions:s,state:fe},we=function(){return{isChimeInitialized:!1,meetingResponse:null,attendeeResponse:null,loading:!1}};function ye(e){return e.isChimeInitialized}function Oe(e){return e.meetingResponse}function je(e){return e.attendeeResponse}function xe(e){return e.attendeeResponse?e.attendeeResponse.Attendee.AttendeeId:null}function ke(e){return e.loading}var Ce=r("f508");function Pe(e,n){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var t=Object.getOwnPropertySymbols(e);n&&(t=t.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),r.push.apply(r,t)}return r}function Re(e){for(var n=1;n<arguments.length;n++){var r=null!=arguments[n]?arguments[n]:{};n%2?Pe(Object(r),!0).forEach((function(n){D()(e,n,r[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):Pe(Object(r)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(r,n))}))}return e}function Me(e,n){e.loading=n}function Se(e,n){if(Ce["a"].hide(),e.loading=!1,console.log(n),!n||n.error)return O["a"].create({message:"Oops, an error occured, please try again",color:"warning"});Object.assign(e,Re(Re({},n),{},{isChimeInitialized:!0}))}function Ie(e,n){if(Ce["a"].hide(),e.loading=!1,!n||n.error)return O["a"].create({message:"Oops, an error occured, please try again",color:"warning"});Object.assign(e,Re(Re({},n),{},{isChimeInitialized:!0}))}function Ee(e){e.isChimeInitialized=!1,e.meetingResponse=null,e.attendeeResponse=null}function Le(e,n){return Ae.apply(this,arguments)}function Ae(){return Ae=h()(g.a.mark((function e(n,r){return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return me()(n),e.prev=1,Ce["a"].show(),e.next=5,Q.invoke("CreateChimeMeeting",r);case 5:e.next=10;break;case 7:return e.prev=7,e.t0=e["catch"](1),e.abrupt("return",!1);case 10:case"end":return e.stop()}}),e,null,[[1,7]])}))),Ae.apply(this,arguments)}function ze(e,n){return _e.apply(this,arguments)}function _e(){return _e=h()(g.a.mark((function e(n,r){return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return me()(n),e.prev=1,Ce["a"].show(),e.next=5,Q.invoke("JoinChimeMeeting",r);case 5:e.next=10;break;case 7:return e.prev=7,e.t0=e["catch"](1),e.abrupt("return",!1);case 10:case"end":return e.stop()}}),e,null,[[1,7]])}))),_e.apply(this,arguments)}var De={namespaced:!0,getters:l,mutations:f,actions:p,state:we};v["a"].use(S["a"]);var Je=function(){var e=new S["a"].Store({modules:{room:re,user:le,message:be,chime:De},strict:!1});return e},Te=r("8c4f"),Be=[{path:"/",component:function(){return Promise.all([r.e(0),r.e(2)]).then(r.bind(null,"713b"))},children:[{path:"",name:"Video chat",meta:{icon:"fas fa-video"},component:function(){return Promise.all([r.e(0),r.e(3)]).then(r.bind(null,"8b24"))}},{path:"/messages",name:"Messages",meta:{icon:"fas fa-comments"},component:function(){return Promise.all([r.e(0),r.e(4)]).then(r.bind(null,"d64f"))}}]}];Be.push({path:"*",component:function(){return Promise.all([r.e(0),r.e(5)]).then(r.bind(null,"e51e"))}});var Ve=Be;v["a"].use(Te["a"]);var Ne=function(){var e=new Te["a"]({scrollBehavior:function(){return{x:0,y:0}},routes:Ve,mode:"history",base:"/"});return e},qe=function(){return Ue.apply(this,arguments)};function Ue(){return Ue=h()(g.a.mark((function e(){var n,r,t;return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:if("function"!==typeof Je){e.next=6;break}return e.next=3,Je({Vue:v["a"]});case 3:e.t0=e.sent,e.next=7;break;case 6:e.t0=Je;case 7:if(n=e.t0,"function"!==typeof Ne){e.next=14;break}return e.next=11,Ne({Vue:v["a"],store:n});case 11:e.t1=e.sent,e.next=15;break;case 14:e.t1=Ne;case 15:return r=e.t1,n.$router=r,t={router:r,store:n,render:function(e){return e(M)}},t.el="#q-app",e.abrupt("return",{app:t,store:n,router:r});case 20:case"end":return e.stop()}}),e)}))),Ue.apply(this,arguments)}var $e=r("9483");r("e519");Object($e["a"])("/service-worker.js",{ready:function(){},registered:function(){},cached:function(){},updatefound:function(){},updated:function(){},offline:function(){},error:function(){}});var Fe=r("a925"),He={failed:"Action failed",success:"Action was successful"},Ke={"en-us":He};v["a"].use(Fe["a"]);var Qe=new Fe["a"]({locale:"en-us",fallbackLocale:"en-us",messages:Ke}),Ge=function(e){var n=e.app;n.i18n=Qe},We=r("bc3a"),Xe=r.n(We);v["a"].prototype.$axios=Xe.a;var Ye=r("1dce"),Ze=r.n(Ye),en=function(e){var n=e.Vue;n.use(Ze.a)},nn=function(e){var n=e.Vue;n.directive("hover-shadow",{bind:function(e){function n(){e.classList.add("shadow-10")}function r(){e.classList.remove("shadow-10")}e.style.transition="0.2s",e.addEventListener("mouseover",n,!1),e.addEventListener("mouseout",r,!1)}})};function rn(){return tn.apply(this,arguments)}function tn(){return tn=h()(g.a.mark((function e(){var n,r,t,a,o,i,u,c,s;return g.a.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,qe();case 2:n=e.sent,r=n.app,t=n.store,a=n.router,o=!0,i=function(e){o=!1,window.location.href=e},u=window.location.href.replace(window.location.origin,""),c=[Ge,void 0,en,X,nn],s=0;case 11:if(!(!0===o&&s<c.length)){e.next=29;break}if("function"===typeof c[s]){e.next=14;break}return e.abrupt("continue",26);case 14:return e.prev=14,e.next=17,c[s]({app:r,router:a,store:t,Vue:v["a"],ssrContext:null,redirect:i,urlPath:u});case 17:e.next=26;break;case 19:if(e.prev=19,e.t0=e["catch"](14),!e.t0||!e.t0.url){e.next=24;break}return window.location.href=e.t0.url,e.abrupt("return");case 24:return console.error("[Quasar] boot error:",e.t0),e.abrupt("return");case 26:s++,e.next=11;break;case 29:if(!1!==o){e.next=31;break}return e.abrupt("return");case 31:new v["a"](r);case 32:case"end":return e.stop()}}),e,null,[[14,19]])}))),tn.apply(this,arguments)}/iPad|iPhone|iPod/.test(navigator.userAgent)&&!window.MSStream&&window.navigator.standalone&&r.e(0).then(r.t.bind(null,"a0db",7)),rn()},"643e":function(e,n){}});