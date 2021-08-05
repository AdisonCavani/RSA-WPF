# RSA

[![name](https://img.shields.io/github/license/AdisonCavani/RSA-WPF)](https://github.com/AdisonCavani/RSA-WPF/blob/master/LICENSE)
[![name](https://img.shields.io/github/v/release/AdisonCavani/RSA-WPF)](https://github.com/AdisonCavani/RSA-WPF/releases/latest)


Application let user to encrypt, decrypt and generate key pair using RSA asymetric encryption. <br>
It can be used to send symetric key like AES or short message - depending on key lenght (longer key = longer message).<br><br>

<p align="left">
<img src="https://raw.githubusercontent.com/AdisonCavani/RSA-WPF/master/docs/Generate.png" width="70%"/>
</p><br>

## Get started
 - [Installation](#installation)
   * [Installing application](#installing-application)
   * [Supported OS](#supported-os)

 - [FAQ](#faq)
   * [How to use this?](#how-to-use-this)
   * [What key size should I use?](#what-key-size-should-i-use)
   * [Message complexity problem](#message-complexity-problem)
   * [How should I store my private and public key?](#how-should-i-store-my-private-and-public-key)


## Installation

### Installing application

Download latest .zip package from [here](https://github.com/AdisonCavani/RSA-WPF/releases/latest).<br>
Unzip and run ``setup.exe``. Follow installer instructions.

### Supported OS

Currently this application support only Windows. <br>
In the future I might port app to Linux with GTK or MAUI.

## FAQ

### How to use this?

You can watch [this](https://www.youtube.com/watch?v=GSIDS_lvRv4) explanatory video or read example below.<br>

<b>Alice</b> want to send a message to <b>Bob</b>.
Of course we don't want to send unencrypted message, because somebody can read our private messages.
Bob need to generate a key pair - ```public``` and ```private``` key.
Then, Bob will send his public key to Alice and she will encrypt her message using Bob's public key.
After encrypting message, Alice will send encrypted message (cipher) to Bob.
Message is secure, because you can only decrypt message using Bob's private key.
When Bob receive encrypted message, he will decrypt it using his private key.<br>

<b>Encrypting plain text with public key is a one-way operation - it cannot be undone using public key.</b>

### What key size should I use?

512 bit key is unsafe and it can be cracked in a few seconds on modern PC. Currently longest cracked key is 795 bits.<br>
My recommendation is to use 2048 bit keys just like TLS protocol.<br>
Be aware that longer key will use more resources and slow down encryption, decryption and key generation.<br>
With every doubling of the RSA key length, decryption is 6-7 times times slower.

Key lenght | Security
------------ | -------------
<i>512 bit | <i>Unsafe, can be cracked in a few seconds
1024 bit | Not recommended
<b>2048 bit | <b>Recommended minimum
3072 bit | Longer is better, use if you can afford it
4096 bit | Longer is better, use if you can afford it

### Message complexity problem

Main limitation of RSA algorithm is a limit of data lenght. <br>
Short key will limit message lenght.<br>
If you exceed data limit, you will get "cryptographic exception" dialog.
 
Key lenght | Data
------------ | -------------
512 bit  | 26 characters
1024 bit | 58 characters
2048 bit | 122 characters
3072 bit | 186 characters
4096 bit | 250 characters
 
### How should I store my private and public key?

The best solution is to use a offline password manager, for example: [KeePassXC](https://keepassxc.org).<br>
<b>Do not store private key in .txt file or any other unencrypted file!</b>
