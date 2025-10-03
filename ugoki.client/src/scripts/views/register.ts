// views/Register.ts
import { ref } from "vue";
import { Navigation } from "@/scripts/navigation/navigation";
import { RegisterAsync } from "@/services/authService";
import { RegisterViewHidration } from "../ViewHidration/authenticationHidration";

import type { ApiResponse, UserRegisterDTO } from "@/types";

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

    async formSubmitted(): Promise<undefined> {
        try {
            if (this.form.value.password !== this.form.value.confirmationPassword || 
                this.form.value.email !== this.form.value.confirmationEmail) {
                
                this.errorMessage.value = "The passwords inserted do not match";

                return;
            }

            const userData: UserRegisterDTO = {
                email: this.form.value.email,
                password: this.form.value.password,
                username: this.form.value.username,
            };

            this.errorMessage.value = "";
            const registrationResult = await RegisterAsync(userData);

            if(!registrationResult.success) {
                // TODO: this was an error, we have the message in registrationResult.error
                // See how to handle it and show it to the user
                this.errorMessage.value = registrationResult.info;
                return;
            }

            const navigation = new Navigation("register");
            navigation.navigateTo("login");
        } catch (err) {
            console.error("Registration failed", err);
            return;
        }
    }
}
