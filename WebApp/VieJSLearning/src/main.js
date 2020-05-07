import Vue from 'vue';
import app from './App.vue';
import vuetify from './plugins/vuetify';
import Layout from './pages/Layout.vue';
import './styles/style.css'
import Vuelidate from 'vuelidate'
import axios from 'axios';
import VueAxios from 'vue-axios';
import router from './router';
import Notifications from 'vue-notification'

Vue.use(Vuelidate);
Vue.use(VueAxios, axios);
Vue.use(Notifications);
Vue.router = router;

Vue.component('layout', Layout);

Vue.config.productionTip = false;
Vue.axios.defaults.baseURL = 'https://localhost:44346/api';

new Vue({
    vuetify,
    router,
    render: h => h(app)
}).$mount('#app');