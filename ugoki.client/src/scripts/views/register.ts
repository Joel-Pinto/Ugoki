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

    async formSubmitted(): Promise<ApiResponse | undefined> {
        try {
            if (this.form.value.password !== this.form.value.confirmationPassword || 
                this.form.value.email !== this.form.value.confirmationEmail) {
                
                var newResponse: ApiResponse = new Object() as ApiResponse;
                newResponse.success = false;
                newResponse.error = "The passwords inserted do not match";

                return newResponse;
            }

            const userData: UserRegisterDTO = {
                email: this.form.value.email,
                password: this.form.value.password,
                username: this.form.value.username,
            };

            const registrationResult = await RegisterAsync(userData);

            if(!registrationResult.success) {
                // TODO: this was an error, we have the message in registrationResult.error
                // See how to handle it and show it to the user
                return registrationResult;
            }

            const navigation = new Navigation("register");
            navigation.navigateTo("login");
            
            return registrationResult;
        } catch (err) {
            console.error("Registration failed", err);
            return undefined;
        }
    }
}
