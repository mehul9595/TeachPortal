export const validateEmail = (email: string): boolean => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
};

export const validateRequiredField = (value: string): boolean => {
    return value.trim() !== '';
};

export const validatePassword = (password: string): boolean => {
    return password.length >= 6; // Example: minimum length of 6 characters
};

export const validateStudentFields = (firstname: string, lastname: string, email: string): boolean => {
    return validateRequiredField(firstname) && 
           validateRequiredField(lastname) && 
           validateEmail(email);
};

export const validateTeacherFields = (username: string, email: string, password: string): boolean => {
    return validateRequiredField(username) && 
           validateEmail(email) && 
           validatePassword(password);
};

export const validateLogin = (formData: { username: string; password: string }): string | null => {
    if (!formData.username) {
        return 'Username is required.';
    }
    if (!formData.password) {
        return 'Password is required.';
    }
    return null;
};

export const validateSignUp = (formData: { username: string; email: string; firstname: string; lastname: string; password: string }): string | null => {
    if (!formData.firstname) {
        return 'First name is required.';
    }
    if (!formData.lastname) {
        return 'Last name is required.';
    }
    if (!formData.email || !validateEmail(formData.email)) {
        return 'A valid email is required.';
    }
    if (!formData.username) {
        return 'Username is required.';
    }
    if (!validatePassword(formData.password)) {
        return 'Password must be at least 6 characters long.';
    }
    return null;
};