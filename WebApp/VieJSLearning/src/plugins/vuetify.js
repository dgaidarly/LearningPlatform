import Vue from 'vue';
import Vuetify, {
    VApp, VNavigationDrawer, VBtn, VIcon, VTextField, VSimpleTable, VForm, VContainer, VRow, VCol, VDataTable, VCard, VCardTitle, VSpacer
    , VList
    , VListItem
    , VListItemIcon
    , VListItemContent
    , VListItemTitle
    , VContent
} from 'vuetify/lib';
import ru from 'vuetify/es5/locale/ru';
import colors from 'vuetify/lib/util/colors';
Vue.use(Vuetify, {
    components: {
        VApp,
        VNavigationDrawer,
        VList
        , VListItem
        , VListItemIcon
        , VListItemContent
        , VListItemTitle
        , VBtn
        , VContent
        , VIcon,
        VTextField,
        VSimpleTable,
        VForm,
        VContainer,
        VRow,
        VCol,
        VDataTable,
        VCard,
        VCardTitle,
        VSpacer
    }
});


export default new Vuetify({
    icons: {
        iconfont: 'mdi'
    },
    theme: {
        options: {
            customProperties: true
        },
        light: true,
        themes: {
            light: {
                primary: colors.lightBlue.darken1,
                secondary: colors.lightBlue.darken1,
                tertiary: colors.blueGrey.darken4,
                accent: colors.lightBlue.accent4,
                error: colors.red,
                info: colors.lightBlue.accent4,
                success: colors.green,
                warning: colors.yellow.darken2,
                anchor: colors.white
            }
        }
    },
    lang: {
        locales: {
            ru
        },
        current: 'ru'
    }
});