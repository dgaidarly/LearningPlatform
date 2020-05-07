<template>
    <v-app>
        <notifications group="userRegistration" />
        <router-view v-if="$route.meta.withoutLayout" />
        <layout v-if="!$route.meta.withoutLayout">
            <v-container fluid>
                <router-view />
            </v-container>
        </layout>
    </v-app>
</template>

<!--<script>
import { EventBus } from './plugins/event-bus';

export default {
  name: 'App',
  created: function() {
    EventBus.$on('error', error => {
      this.$toast.error(error);
    });

    EventBus.$on('success', data => {
      this.$toast(data.message);
    });

    EventBus.$on('loader:show', () => {
      this.$loading(true);
    });

    EventBus.$on('loader:hide', () => {
      this.$loading(false);
    });
  }
    };
</script>-->