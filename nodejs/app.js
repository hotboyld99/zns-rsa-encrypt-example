const forge = require("node-forge");
const fs = require("fs");

const publicKeyPem = fs.readFileSync("../public_key.pem", "utf8");
const publicKey = forge.pki.publicKeyFromPem(publicKeyPem);

const text = "abc123";

const encrypted = publicKey.encrypt(text, "RSA-OAEP", {
    md: forge.md.sha256.create(), // OAEP hash
    mgf1: {
        md: forge.md.sha1.create(), // MGF1 hash
    },
});

const res = forge.util.encode64(encrypted);

console.log("Encrypted data: " + res);
