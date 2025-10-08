// views/Register.ts
import { ref } from "vue";
import { RegisterAsync } from "@/services/authService";
import { RegisterViewHidration } from "../ViewHidration/authenticationHidration";

import {router } from "@/scripts/router";

import type { UserRegisterDTO } from "@/types";
import type { ErrorHandler } from "@/services/errorHandler"; // type-only

import loginImage from "../../assets/images/login/login_background.png";


export class Register {
    hidration = RegisterViewHidration();
    loginImage = ref(loginImage);
    passwordFieldType = ref<"password" | "text">("password");
    repeatPasswordFieldType = ref<"password" | "text">("password");
    errorMessage = ref(""); 

    form = ref({
        email: "",
        confirmationEmail: "",
        password: "",
        confirmationPassword: "",
        username: "",
    });

    togglePasswordVisibility(): void {
        this.passwordFieldType.value =
            this.passwordFieldType.value === "password" ? "text" : "password";
        this.repeatPasswordFieldType.value =
            this.repeatPasswordFieldType.value === "password" ? "text" : "password";
    }

    async formSubmitted(): Promise<void> {
        try {
            if (
                this.form.value.password !== this.form.value.confirmationPassword ||
                this.form.value.email !== this.form.value.confirmationEmail
            ) {
                this.errorMessage.value = "The passwords do not match!"
                return;
            }

            const userData: UserRegisterDTO = {
                email: this.form.value.email,
                password: this.form.value.password,
                username: this.form.value.username,
            };

            this.errorMessage.value = "";

            const registrationResult = await RegisterAsync(userData);

            if (!registrationResult.success) {
                const error = registrationResult as ErrorHandler;

                if (error.details && error.details.length > 0) {
                    this.errorMessage.value = error.details
                        .map((d) => `• ${d.description}`)
                        .join("<br/>");
                } else {
                    this.errorMessage.value = error.message;
                }
                return;
            }
            this.errorMessage.value = "Login Successfull";
            router.push({ name: "Login" });
        } catch (err) {
            console.error("Registration failed", err);
            this.errorMessage.value = "Something went wrong. Please try again later.";
        }
    }
}
