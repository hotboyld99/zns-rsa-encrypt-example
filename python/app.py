import base64

from cryptography.hazmat.primitives import serialization, hashes
from cryptography.hazmat.primitives.asymmetric import padding

with open("../public_key.pem", "rb") as key_file:
    public_key = serialization.load_pem_public_key(key_file.read())

text = b"abc123"

encrypted = public_key.encrypt(
    text,
    padding.OAEP(
        mgf=padding.MGF1(algorithm=hashes.SHA1()),
        algorithm=hashes.SHA256(),
        label=None
    )
)

result = base64.b64encode(encrypted).decode()
print("Encrypted data: " + result)
