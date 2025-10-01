// views/Login.ts
import { ref } from "vue";
import { LoginViewHidration } from "../ViewHidration/authenticationHidration";
import loginImage from "../../assets/images/login/login_background.png";
import { LoginAsync } from "@/services/authService";
import type { UserLoginDTO } from "@/types";

export class Login {
    hidration = { ...LoginViewHidration() };
    loginImage = ref(loginImage);
    passwordFieldType = ref<"password" | "text">("password");
    rememberUser = ref(false);
    form = ref({
        email: "",
        password: "",
    });

    togglePasswordVisibility(): void {
        this.passwordFieldType.value =
            this.passwordFieldType.value === "password" ? "text" : "password";
    }

    async formSubmitted(): Promise<void> {
        if (!this.form.value.email || !this.form.value.password) {
            // TODO: show error
            return;
        }

        try {
            const userData: UserLoginDTO = {
                password: this.form.value.password,
                email: this.form.value.email,
            };
            const result = await LoginAsync(userData);
        } catch (err) {
            console.error("Login failed", err);
        }
    }
}
