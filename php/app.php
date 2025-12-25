<?php

require __DIR__ . '/vendor/autoload.php';

use phpseclib3\Crypt\PublicKeyLoader;
use phpseclib3\Crypt\RSA;

$publicKey = file_get_contents(__DIR__ . '/../public_key.pem');

$text = 'qwerty';

$textEncrypted = PublicKeyLoader::loadPublicKey($publicKey)
    ->withPadding(RSA::ENCRYPTION_OAEP)
    ->withHash('sha256')
    ->withMGFHash('sha1')
    ->encrypt($text);

$res = base64_encode($textEncrypted);

echo 'Encrypted data: ' . $res . "\n";
