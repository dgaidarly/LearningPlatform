<template>
    <v-app>
        <v-navigation-drawer app
                                                   expand-on-hover
                                                   mini-variant
                                                   clipped
                                                   color="blue-grey darken-4"
                                                   dark
                                                   permanent>
            <v-list dense nav>
                <v-list-item v-for="item in items"
                             :key="item.title"
                             link
                             :to="item.link">
                    <v-list-item-icon>
                        <v-icon>{{ item.icon }}</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>{{ item.title }}</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
        </v-navigation-drawer>
        <v-content>
            <v-container fluid>
                <router-view></router-view>
            </v-container>
        </v-content>
    </v-app>
</template>

<script>
    export default {
        data: () => ({
            items: [
                {
                    title: 'Регистрация',
                    icon: 'mdi-account-plus',
                    link: '/registered',
                }
            ],
        }),
    };
</script>
