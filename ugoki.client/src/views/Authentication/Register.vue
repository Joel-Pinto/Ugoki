<style src="../../assets/css/authentication/login.css" scoped></style>

<script lang="ts" setup>
import { Register } from '@/scripts/views/register.ts';

const register = new Register();
const hidration = register.hidration;

</script>

<template>
  <div class="login-container register">
    <div class="login-page">
      <div class="image-wrapper">
        
        <img :src="register.loginImage.value" class="image-placeholder" title="Login page image"></img>

        <div class="image-text-overlay">
          <div class="wise-quote-badge">{{ hidration.aWiseQuote }}</div>
          <div class="main-quote">
            <h1>Get<br>Everything<br>You Want</h1>
            <p>
              {{ hidration.imageMainSubtitle }}
            </p>
          </div>
        </div>
      </div>

      <div class="form-section-wrapper">
        <div class="form-section">
          <div class="logo">
            <span class="logo-dot"></span> Cogie
          </div>

          <div class="welcome-text">
            <h2 class="welcome-h2">{{ hidration.title }}</h2>
            <p>{{ hidration.subtitle }}</p>
          </div>

          <form @submit.prevent="register.formSubmitted" class="login-form">
            <div class="form-group">
              <label for="username">{{ hidration.username }}</label>
              <input id="username" type="text" v-model="register.form.value.username" :placeholder="hidration.username" />
            </div>

            <div class="form-group">
              <label for="email">{{ hidration.email }}</label>
              <input id="email" type="email" v-model="register.form.value.email" :placeholder="hidration.emailPlaceholder" />
            </div>

            <div class="form-group">
              <label for="repeat-email">{{ hidration.retypeEmail }}</label>
              <input id="repeat-email" type="email" v-model="register.form.value.confirmationEmail" :placeholder="hidration.retypeEmail" />
            </div>

            <div class="form-group">
              <label for="password">{{ hidration.password }}</label>
              <div class="password-input-wrapper">
                 <input id="password" :type="register.passwordFieldType.value" v-model="register.form.value.password" :placeholder="hidration.passwordPlaceholder"/>
                 <svg @click="register.togglePasswordVisibility" xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-eye eye-icon"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle></svg>
              </div>
            </div>

            <div class="form-group">
              <label for="repeat-password">{{ hidration.retypePassword }}</label>
              <div class="password-input-wrapper">
                 <input id="repeat-password" :type="register.repeatPasswordFieldType.value" v-model="register.form.value.confirmationPassword" :placeholder="hidration.retypePassword"/>
                 <svg @click="register.togglePasswordVisibility" xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-eye eye-icon"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle></svg>
              </div>
            </div>

            <button class="btn btn-signin" type="submit">{{ hidration.signUp }}</button>

            <div class="error-box">
              <div>
                <p>{{ register.errorMessage }}</p>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>
