import re

def header_parsing(line):
    m = re.match('#{1,6} ', line) # A header is composed of 1 to 6 #s and a space.
    if m:
        size = m.end() -1 # We remove the space's position.
        line = f'<h{size}>{line[(size+1):]}</h{size}>' # This is the pattern of the header.
    return line


def add_paragraph(line):
    # This verifies for any of the possible tags. If they aren't there, you add the paragraph marker.
    m = re.match('<h|<ul|<p|<li', line)
    if not m:
        line = f"<p>{line}</p>"
    return line

# These must be two functions because you CAN have both bold and italics. 
def parse_bold(line):
    m = re.match('(.*)__(.*)__(.*)', line) # Look for bold
    if m:
        line = f"{m.group(1)}<strong>{m.group(2)}</strong>{m.group(3)}" # parse bold
    return line


def parse_italic(line):
    m = re.match('(.*)_(.*)_(.*)', line) # Look for italics.
    if m:
        line = f"{m.group(1)}<em>{m.group(2)}</em>{m.group(3)}" # parse italics.
    return line 


def parse_bold_italics(line):
    return parse_italic(parse_bold(line))


def parse(markdown):
    lines = markdown.split('\n')
    res = ''
    in_list = False
    in_list_append = False
    for i in lines:
        i = header_parsing(i)
        m = re.match(r'\* (.*)', i) # Here we match for an *, which indicates a list
        if m: # If you have a list
            curr = m.group(1) # This gets whatever comes after the list signaling
            curr = parse_bold_italics(curr)
            i = f"<li>{curr}</li>" # Anything inside a list gets the list item tag.
            if not in_list:
                in_list = True # We mark that we are now inside of a list
                i = f"<ul>{i}" # The first part of the list will put an <ul> in the beggining of the list.
        else: # If we don't match for a list
            if in_list: # If we WERE inside a list
                in_list_append = True
                in_list = False # Now we are out, because we've seen its end in another line. 
        i = add_paragraph(i)
        i = parse_bold_italics(i)
        if in_list_append:
            i = '</ul>' + i
            in_list_append = False
        res += i
    if in_list:
        res += '</ul>'
    return res
