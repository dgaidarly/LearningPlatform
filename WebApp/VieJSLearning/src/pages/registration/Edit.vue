<template>
    <div>
        <v-row class="fs-container">
            <v-form ref="form"
                    id="formId"
                    v-model="valid">
                <h1 class="registrationTitle text-center">Форма регистрации</h1>
                <v-row>
                    <v-col>
                        <v-text-field v-model="name"
                                      :rules="nameRules"
                                      :counter="20"
                                      label="Имя"
                                      required />
                        <v-text-field v-model="surname"
                                      :rules="surnameRules"
                                      :counter="50"
                                      label="Фамилия"
                                      required />
                        <v-text-field v-model="email"
                                      :rules="emailRules"
                                      label="Почта" />
                        <v-text-field v-model="password"
                                      type="password"
                                      :rules="passwordRules"
                                      :counter="50"
                                      label="Пароль"
                                      required />
                        <v-btn @click="submit"
                               width="400px"
                               :disabled="!valid">
                            Зарегистрироваться
                        </v-btn>
                    </v-col>
                </v-row>
            </v-form>
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
                v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
            ],
            password: '',
            passwordRules: [
                v => !!v || 'Password is required'
            ],
            user: ''
        }),

        computed: {
            isFormValid() {
                this.$refs.form.validate();
            },
        },

        methods: {
            submit(event) {
                this.user = {
                    firstName: this.name,
                    secondName: this.surname,
                    mail: this.email,
                    password: this.password,
                };
                this.saveUser();
                event.preventDefault();
            },
            clear() {
                this.$refs.form.reset();
                this.$refs.form.resetValidation();
            },
            saveUser() {
                axios
                    .post('Registration', this.user)
                    .then(response => {
                        if (response.data !== '') {
                            this.$notify({
                                type: 'error',
                                group: 'userRegistration',
                                title: 'Ошибка!',
                                text: response.data
                            });
                        }
                        else {
                            this.$router.push('/registered');
                            this.clear();
                        }
                    });
            }
        }
    };
</script>