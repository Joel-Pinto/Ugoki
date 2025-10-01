// views/Register.ts
import { ref } from "vue";
import { RegisterViewHidration } from "../ViewHidration/authenticationHidration";
import loginImage from "../../assets/images/login/login_background.png";
import { RegisterAsync } from "@/services/authService";
import type { UserRegisterDTO } from "@/types";

export class Register {
    hidration = RegisterViewHidration();
    loginImage = ref(loginImage);
    passwordFieldType = ref<"password" | "text">("password");
    repeatPasswordFieldType = ref<"password" | "text">("password");

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
            if (this.form.value.password !== this.form.value.confirmationPassword || 
                this.form.value.email !== this.form.value.confirmationEmail) {
                // TODO: show error
                return;
            }
            const userData: UserRegisterDTO = {
                email: this.form.value.email,
                password: this.form.value.password,
                username: this.form.value.username,
            };
            const registrationResult = await RegisterAsync(userData);

            if(!registrationResult?.success) {
                // TODO: this was an error, we have the message in registrationResult.error

            }
        } catch (err) {
            console.error("Registration failed", err);
        }
    }
}
