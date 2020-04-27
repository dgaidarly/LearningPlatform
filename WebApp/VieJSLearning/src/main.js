import Vue from 'vue';
import Hello from './pages/UserRegistration.vue';
import vuetify from './plugins/vuetify';
import './styles/style.css'
import Vuelidate from 'vuelidate'
import axios from 'axios';
import VueAxios from 'vue-axios';
import router from './router';
Vue.use(Vuelidate);
Vue.use(VueAxios, axios);
Vue.router = router;

Vue.config.productionTip = false;
Vue.axios.defaults.baseURL = 'https://localhost:44346/api';

new Vue({
    vuetify,
    router,
  render: h => h(Hello)
}).$mount('#app');