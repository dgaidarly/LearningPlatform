<template>
    <div>
        <v-row>
            <v-col class="d-flex justify-start">
                <h1>Пользователи</h1>
            </v-col>
            <v-col class="d-flex justify-end">
                <v-btn @click="onEdit()">Зарегистрироваться</v-btn>
            </v-col>
        </v-row>
        <v-card>
            <v-card-title>
                <v-spacer></v-spacer>
                <v-text-field v-model="search"
                              append-icon="mdi-magnify"
                              label="Search"
                              single-line
                              hide-details></v-text-field>
            </v-card-title>
            <v-data-table :headers="headers"
                          :search="search"
                          :items="users"
                          :items-per-page="5"
                          class="elevation-3"></v-data-table>
        </v-card>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        data: () => ({
            instanceId: 'registration',
            instance: 'registered',
            search: '',
            users: [],
            headers: [
                {text: 'Имя', align: 'left', sortable: false, value: 'firstName'},
                {text: 'Фамилия', value: 'secondName'},
                {text: 'Почта', value: 'mail'}
            ],
        }),

        methods: {
            loadHelloWorld() {
                axios
                    .get('Registration/GetAll')
                    .then(response => {
                        this.users = response.data;
                    });
            },
            onEdit: function (item) {
                let id = item ? item.id : '';
                this.$router.push(`/${this.instanceId}/${id}`);
            },
        },

        created() {
            this.loadHelloWorld();
        }
    };
</script>