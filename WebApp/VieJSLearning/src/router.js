import Vue from 'vue';
import Router from 'vue-router';
import Registration from '@/pages/registration/Edit';
import Registered from '@/pages/registration/Index';

Vue.use(Router);

const router = new Router({
    mode: 'history',
    routes: [
        {
            path: '/registered',
            name: 'registered',
            component: Registered,
            meta: {
                title: 'Список пользователей'
            }
        },
        {
            path: '/registration',
            name: 'registration',
            component: Registration,
            meta: {
                title: 'Регистрация'
            }
        },
        {
            path: '',
            redirect: 'registered'
        }
    ]
});

router.beforeEach((to, from, next) => {
    document.title = `Регистрация ${
        to.meta.title ? ' | ' + to.meta.title : ''
        }`;
    next();
});

export default router;