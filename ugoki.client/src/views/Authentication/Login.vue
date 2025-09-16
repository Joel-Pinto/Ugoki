<style src="../../assets/css/authentication/login.css" scoped></style>

<script lang="ts" setup>
import { Login } from '../../scripts/Authentication/login.ts';

const login = new Login();
console.log(login.passwordFieldType.value)
const hidration = login.hidration;
</script>

<template>
  <div class="login-container">
    <div class="login-page">
      <div class="image-wrapper">
        
        <img :src="login.loginImage.value" class="image-placeholder" title="Login page image"></img>

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

          <form @submit.prevent="login.formSubmitted" class="login-form">
            <div class="form-group">
              <label for="email">{{ hidration.email }}</label>
              <input id="email" type="email" v-model="login.form.value.email" :placeholder="hidration.emailPlaceholder" />
            </div>

            <div class="form-group">
              <label for="password">{{ hidration.password }}</label>
              <div class="password-input-wrapper">
                 <input id="password" :type="login.passwordFieldType.value" v-model="login.form.value.password" :placeholder="hidration.passwordPlaceholder"/>
                 <svg @click="login.togglePasswordVisibility" xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-eye eye-icon"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle></svg>
              </div>
            </div>

            <div class="form-options">
              <div class="remember-me">
                <input type="checkbox" id="rememberMe" v-model="login.rememberUser" />
                <label for="rememberMe">{{ hidration.rememberMe }}</label>
              </div>
              <a href="#" class="forgot-password">{{ hidration.forgotPassword }}</a>
            </div>

            <button class="btn btn-signin" type="submit">{{ hidration.signIn }}</button>
            <button class="btn btn-google" type="button">
                <svg width="20" height="20" viewBox="0 0 18 18" fill="none" xmlns="http://www.w3.org/2000/svg" class="google-icon"><path d="M17.64 9.20455C17.64 8.56682 17.5827 7.95273 17.4764 7.36364H9V10.845H13.8436C13.635 11.97 13.0009 12.9232 12.0477 13.5614V15.8195H14.9564C16.6582 14.2527 17.64 11.9455 17.64 9.20455Z" fill="#4285F4"></path><path d="M9 18C11.43 18 13.4673 17.1941 14.9564 15.8195L12.0477 13.5614C11.2418 14.1014 10.2109 14.4205 9 14.4205C6.96182 14.4205 5.23727 13.0127 4.63091 11.1818H1.61182V13.5091C3.10091 16.2055 5.83455 18 9 18Z" fill="#34A853"></path><path d="M4.63091 11.1818C4.42273 10.5682 4.3 9.90591 4.3 9.20455C4.3 8.50318 4.42273 7.84091 4.63091 7.22727V4.9H1.61182C0.949091 6.22364 0.5 7.665 0.5 9.20455C0.5 10.7441 0.949091 12.1855 1.61182 13.5091L4.63091 11.1818Z" fill="#FBBC05"></path><path d="M9 3.98864C10.2955 3.98864 11.5073 4.44409 12.4409 5.32136L15.0218 2.74045C13.4673 1.25136 11.43 0.409091 9 0.409091C5.83455 0.409091 3.10091 2.19455 1.61182 4.9L4.63091 7.22727C5.23727 5.39636 6.96182 3.98864 9 3.98864Z" fill="#EA4335"></path></svg>
              {{ hidration.signInWithGoogle }}
            </button>
          </form>

          <div class="signup-link">
            <p>{{ hidration.noAccount }} <a href="/ugoki.client/src/components/Authentication/Register.vue">{{ hidration.signUp }}</a></p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
