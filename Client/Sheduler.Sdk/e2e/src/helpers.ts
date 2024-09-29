export const id = () =>Array.from(crypto.getRandomValues(new Uint8Array(8))).map(x => x.toString(16)).join('');
