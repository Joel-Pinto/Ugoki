import { ref } from 'vue';
import { LoginViewHidration, RegisterViewHidration } from '../../scripts/Authentication/authenticationHidration.ts';
import loginImage from '../../assets/images/login/login_background.png';

export class Login 
{
    // variables
    hidration: object;
    loginImage = ref(loginImage);
    passwordFieldType = ref<'password' | 'text'>('password');
    rememberUser = ref(false);
    form = ref({
        email: "",
        password: "",
    });
    
    
    constructor()
    {
        this.hidration = LoginViewHidration();
    }
  
    // Placeholder function for form submission
    formSubmitted(): void 
    {
        console.log("Form submitted with:", this.form.value);
    }

    // Function to toggle password visibility
    togglePasswordVisibility(): void {
        this.passwordFieldType.value = this.passwordFieldType.value === 'password' ? 'text' : 'password';
    }
}

export class Register
{
    hidration: object;
    loginImage = ref(loginImage);
    passwordFieldType = ref<'password' | 'text'>('password');
    repeatPasswordFieldType = ref<'password' | 'text'>('password');
    form = ref({
        email: "",
        confirmationEmail: "",
        password: "",
        username: ""
    });
    constructor() {
        this.hidration = RegisterViewHidration();
    }

    // Placeholder function for form submission
    formSubmitted(): void {
        console.log("Form submitted with:", this.form.value);
    }

    // Function to toggle password visibility
    togglePasswordVisibility(): void {
        this.passwordFieldType.value = this.passwordFieldType.value === 'password' ? 'text' : 'password';
        this.repeatPasswordFieldType.value = this.passwordFieldType.value === 'password' ? 'text' : 'password';
    }
}
