<template>
    <div>
        <v-row class="fs-container">
            <v-form
                    ref="form"
                    id="formId"
                    v-model="valid">
                <h1 class="registrationTitle text-center">Форма регистрации</h1>
                <v-row>
                    <v-col>
                        <v-text-field
                                v-model="name"
                                :rules="nameRules"
                                :counter="20"
                                label="Имя"
                                required
                        />
                        <v-text-field
                                v-model="surname"
                                :rules="surnameRules"
                                :counter="50"
                                label="Фамилия"
                                required
                        />
                        <v-text-field
                                v-model="email"
                                :rules="emailRules"
                                label="Почта"/>
                        <v-text-field
                                v-model="password"
                                type="password"
                                :rules="passwordRules"
                                :counter="50"
                                label="Пароль"
                                required
                        />
                        <v-text-field
                                v-model="helloWord"
                        />
                        <v-btn
                                @click="submit"
                                width="400px"
                        :disabled="!isFormValid">
                           Зарегистрироваться</v-btn>
                    </v-col>
                </v-row>
            </v-form>
        </v-row>
        <v-row>
            <v-col class="fs-container">
                <v-card>
                    <!--<v-text-field
                            v-model="search"
                            label="Search"
                            single-line
                    ></v-text-field>-->
                    <v-data-table
                            :headers="headers"
                            :items="users"
                            :items-per-page="5"
                            class="elevation-3"
                    ></v-data-table>
                </v-card>
            </v-col>
        </v-row>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        data: () => ({
           valid: true,
            name: '',
           nameRules: [
              v => !!v || 'Name is required',
              v => (v && v.length <= 20) || 'Name must be less than 20 characters',
           ],
            surname: '',
           surnameRules: [
              v => !!v || 'Surname is required',
              v => (v && v.length <= 50) || 'Name must be less than 10 characters',
           ],
            email: '',
           emailRules: [
              v =>(v === '' || /.+@.+\..+/.test(v)) || 'E-mail must be valid',
           ],
            password: '',
            passwordRules: [
                v => !!v || 'Password is required'
            ],
            users: [],
            helloWord:'',
            headers: [
                {text: 'Имя', align: 'left', sortable: false, value: 'name'},
                {text: 'Фамилия', value: 'surname'},
                {text: 'Почта', value: 'email'}
            ],
        }),

        computed: {
            // Проверяем, что каждое поле формы валидно
            isFormValid () {

            //debugger;
                //return this.fields.any(field=>field.valid());
                return false;
            },
        },

        methods: {
            submit(event) {
                let user = {
                    name: this.name,
                    surname: this.surname,
                    email: this.email,
                    password: this.password,
                };
                this.users.push(user);
                //
                this.clear();
                event.preventDefault();
            },
            clear(){
                this.$refs.form.reset();
                this.$refs.form.resetValidation();
            },
            loadHelloWorld() {
                axios
                    .get('WeatherForecast/HelloWorld')
                    .then(response => {
                        this.helloWord = response.data;
                    });
            }
        },

        created() {
            this.loadHelloWorld();
        }
    };
</script>