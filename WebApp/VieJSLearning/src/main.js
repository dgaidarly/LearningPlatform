import Vue from 'vue';
import Hello from './components/Hello.vue';
import vuetify from './plugins/vuetify';
import './styles/style.css'
import Vuelidate from 'vuelidate'
Vue.use(Vuelidate);

Vue.config.productionTip = false;

new Vue({
  vuetify,
  render: h => h(Hello)
}).$mount('#app');