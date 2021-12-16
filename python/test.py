import string
alphabet = list(string.ascii_lowercase)

class Cipher:
    
    def __init__(self, shift = 3,key=None):
       
        self.key = alphabet[shift:] + alphabet[:shift]

    def encode(self, text):
        message = ''
        
        for letter in text:
            print(letter, alphabet.index(letter))
            message += self.key[alphabet.index(letter)]
        return message
    def decode(self, text):
        pass
plaintext = "aaaaaaaaaa"
cipher = Cipher()
print(cipher.encode(plaintext))
print(cipher.key[0 : len(plaintext)])