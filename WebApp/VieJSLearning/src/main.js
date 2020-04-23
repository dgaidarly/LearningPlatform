import Vue from 'vue';
import Hello from './components/Hello.vue';
import vuetify from './plugins/vuetify';
import './styles/style.css'
import Vuelidate from 'vuelidate'
import axios from 'axios';
import VueAxios from 'vue-axios';
Vue.use(Vuelidate);
Vue.use(VueAxios, axios);

Vue.config.productionTip = false;
Vue.axios.defaults.baseURL = 'https://localhost:44346/api';

new Vue({
  vuetify,
  render: h => h(Hello)
}).$mount('#app');