import type { LoginHidration, RegisterHidration } from "@/scripts/types/typeDefinition.ts";

export function LoginViewHidration() : LoginHidration
{
    return {
        title: "Welcome Back",
        subtitle: "Enter your email and password to access your account!",
        imageQuote: "A Wise Quote",
        imageMainSubtitle: "You can get everything you want if you work hard, trust the process, and stick to the plan.",
        aWiseQuote: "Make today count",
        emailPlaceholder: "email",
        passwordPlaceholder: "password",
        email:  "Email",
        password: "Password",
        rememberMe: "Remember me",
        signIn: "Sign In",
        forgotPassword: "Forgot Password",
        noAccount: "Don't have an account?",
        signUp: "Sign Up",
        signInWithGoogle: "Sign In with Google"
    }; 
};

export function RegisterViewHidration(): RegisterHidration
{
    return {
        title: "Glad to see you joining! ",
        subtitle: "Enter your email and password and username to create an account!",
        
        aWiseQuote: "Great journeys start with a single step",
        imageMainSubtitle: "You miss 100% of the shots you don't take.",
        
        usernamePlaceholder: "Username",
        emailPlaceholder: "Email",
        passwordPlaceholder: "Password",
        
        username:  "Username",
        email:  "Email",
        password: "Password",
        retypePassword: "Repeat password",
        retypeEmail: "Repeat email",

        rememberMe: "Remember me",
        signUp: "Sign up",

        signUpWithGoogle: "Sign Up with Google"
    }; 
}
