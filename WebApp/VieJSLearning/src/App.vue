<template>
    <v-app>
        <router-view v-if="$route.meta.withoutLayout" />
        <layout v-if="!$route.meta.withoutLayout">
            <v-container fluid>
                <router-view />
            </v-container>
        </layout>
    </v-app>
</template>