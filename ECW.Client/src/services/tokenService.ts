const key = 'authenticated';

class TokenService {
    getLocalAccessToken() {
        const user = JSON.parse(localStorage.getItem(key) as string);
        return user?.token;
    };

    updateLocalAccessToken(token: string) {
        let user = JSON.parse(localStorage.getItem(key) as string);
        user.token = token;
        localStorage.setItem(key, JSON.stringify(user));
    };

    getUser() {
        return JSON.parse(localStorage.getItem(key) as string);
    };

    setUser(user: string) {
        localStorage.setItem(key, JSON.stringify(user));
    };

    removeUser() {
        localStorage.removeItem(key);
    };
};

export default new TokenService();